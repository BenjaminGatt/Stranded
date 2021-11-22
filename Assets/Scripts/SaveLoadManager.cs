using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    public SerializedData serializedData; //An instance of the class SerializedData
    public static SaveLoadManager _saveLoadInstance;

    void Awake() //Awake runs once when the instance of the script is loaded, even if the script is disabled(?). Awake runs before Start.
    {
        if (_saveLoadInstance == null)
        {
            _saveLoadInstance = this;
        }
        else if (_saveLoadInstance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        serializedData = new SerializedData();
    }

    public void SaveMyData()
    {
        string saveJSON;
        serializedData.serializedPlayerLives = GameData.PlayerLives;
        serializedData.serializedMaxPlayerLives = GameData.MaxPlayerLives;
        serializedData.serializedPlayerHP = GameData.PlayerHP;
        serializedData.serializedMaxPlayerHP = GameData.MaxPlayerHP;
        serializedData.serializedPlayerScore = GameData.PlayerScore;
        serializedData.serializedHighScores = GameData.PlayerHighScores;
        serializedData.serializedPlayerWeaponName = GameData.PlayerWeaponName;
        serializedData.serializedBulletNamesArray = GameData.BulletNamesArray;
        serializedData.serializedFireRateArray = GameData.FireRateArray;
        serializedData.serializedBulletSpeedArray = GameData.BulletSpeedArray;
        serializedData.serializedDifficultyLevel = GameData.DifficultyLevel;

        saveJSON = JsonUtility.ToJson(serializedData);
        PlayerPrefs.SetString("StrandedData", saveJSON);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamedata.save");
        bf.Serialize(file, serializedData);
        file.Close();
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Game saved.");
    }

    public void LoadMyData()
    {
        string loadJSON;
        loadJSON = PlayerPrefs.GetString("StrandedData");
        SerializedData serializedLoadJSON = JsonUtility.FromJson<SerializedData>(loadJSON);

        if (serializedLoadJSON != null)
        {
            GameData.PlayerScore = serializedLoadJSON.serializedPlayerScore;
            GameData.PlayerHighScores = serializedLoadJSON.serializedHighScores;
        }

        if (File.Exists(Application.persistentDataPath + "/gamedata.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamedata.save", FileMode.Open);
            SerializedData serializedLoad = (SerializedData)bf.Deserialize(file);

            if (serializedLoad != null)
            {
                GameData.DifficultyLevel = serializedLoad.serializedDifficultyLevel;
                GameData.PlayerLives = serializedLoad.serializedPlayerLives;
                GameData.MaxPlayerLives = serializedLoad.serializedMaxPlayerLives;
                GameData.PlayerHP = serializedLoad.serializedPlayerHP;
                GameData.MaxPlayerHP = serializedLoad.serializedMaxPlayerHP;
                //GameData.PlayerScore = serializedLoad.serializedPlayerScore;
                //GameData.PlayerHighScores = serializedLoad.serializedHighScores;
                GameData.PlayerWeaponName = serializedLoad.serializedPlayerWeaponName;
                GameData.BulletNamesArray = serializedLoad.serializedBulletNamesArray;
                GameData.FireRateArray = serializedLoad.serializedFireRateArray;
                GameData.BulletSpeedArray = serializedLoad.serializedBulletSpeedArray;
            }
            file.Close();
        }
    }
}