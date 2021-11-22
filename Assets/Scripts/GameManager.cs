using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameObject player, bulletPrefab;
    private Transform playerWeaponInstance;
    private UnityEngine.UI.Slider playerHPSlider;
    private int currentSceneIndex;
    private Text playerLivesText, playerScoreText, playerHighScoresText, playerWinLoss;

    SaveLoadManager mySaveLoadManager;

    void Awake() //Awake runs once when the instance of the script is loaded, even if the script is disabled(?). Awake runs before Start.
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        FillBulletPrefabsArray();
        ResetGame();
        mySaveLoadManager = GetComponent<SaveLoadManager>();
        mySaveLoadManager.LoadMyData();
    }

    // Update is called once per frame
    void Update()
    {
        mySaveLoadManager.SaveMyData();
    }

    public GameObject FindPlayer()
    {
        player = GameData.FindPlayerObject;
        return player;
    }

    public void SetPlayerWeapon()
    {
        if (player != null)
        {
            playerWeaponInstance = player.transform.GetChild(0);
            Destroy(playerWeaponInstance.gameObject.GetComponent<EmptyHand>());
            Destroy(playerWeaponInstance.gameObject.GetComponent<Rifle>());
            Destroy(playerWeaponInstance.gameObject.GetComponent<Sniper>());
            Destroy(playerWeaponInstance.gameObject.GetComponent<Shotgun>());
            playerWeaponInstance.gameObject.AddComponent(Type.GetType(GameData.PlayerWeaponName));
        }
        else Debug.Log("Player not found!");
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        Debug.Log("ChangeScene");
        if (_sceneName == "Level0")
        {
            ResetGame();
            Debug.Log("ResetGame");
        }
    }

    public void ChangeScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void DisplayHealth()
    {
        try
        {
            playerHPSlider = GameObject.Find("HPSlider").GetComponent<UnityEngine.UI.Slider>();
            playerHPSlider.value = GameData.PlayerHP;
        }
        catch (NullReferenceException)
        {
            Debug.Log("Health slider not found.");
        }
    }

    public void DisplayLives()
    {
        try
        {
            playerLivesText = GameObject.Find("Lives").GetComponent<Text>();
            playerLivesText.text = $"Lives: {GameData.PlayerLives}";
        }
        catch (NullReferenceException)
        {
            Debug.Log("Lives text field not found.");
        }
    }

    public void DisplayScore()
    {
        try
        {
            playerScoreText = GameObject.Find("Score").GetComponent<Text>();
            playerScoreText.text = $"Score: {GameData.PlayerScore}";
        }
        catch (NullReferenceException)
        {
            Debug.Log("Score text field not found.");
        }
    }

    public void DisplayHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            try
            {
                playerHighScoresText = GameObject.Find("HighScore" + (i + 1)).GetComponent<Text>();
                playerHighScoresText.text = $"{GameData.PlayerHighScores[i]}";
            }
            catch (NullReferenceException)
            {
                Debug.Log($"HighScore{i} text field not found.");
            }
        }
    }

    public void DisplayWinLoss()
    {
        try
        {
            playerWinLoss = GameObject.Find("WinLossText").GetComponent<Text>();
            if (GameData.VictoryCondition)
            {
                playerWinLoss.text = "VICTORY!";
            }
            else if (!GameData.VictoryCondition)
            {
                playerWinLoss.text = "DEFEAT";
            }
            else
            {
                Debug.Log("Error in GameManager.DisplayWinLoss()");
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("WinLossText field not found.");
        }
    }

    public void ProcessEndScore()
    {
        if (GameData.PlayerScore > GameData.PlayerHighScores[4])
        {
            GameData.PlayerHighScores[4] = GameData.PlayerScore;
            Array.Sort(GameData.PlayerHighScores);
            Array.Reverse(GameData.PlayerHighScores);
        }
    }
    public void ProcessPlayerDeath()
    {
        GameData.RoomTrigger = new bool[] { false, false, false, false, false };
        if (GameData.PlayerLives > 1)
        {
            ReduceLife();
            Debug.Log("if statement worked");
        }
        else
        {
            GameData.VictoryCondition = false;
            ProcessEndScore();
            ChangeScene("EndScene");
            ResetGame();
        }
    }

    public void ReduceLife()
    {
        GameData.PlayerLives--;
        Debug.Log("lives reduced");
        GameData.PlayerHP = GameData.MaxPlayerHP;
        Debug.Log("HP reset");
        GameData.PlayerScore = 0;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ChangeScene(currentSceneIndex);
        Debug.Log("scene changed");
    }

    private void ResetGame()
    {
        GameData.PlayerScore = 0;
        GameData.PlayerHP = GameData.MaxPlayerHP;
        GameData.PlayerLives = GameData.MaxPlayerLives;
    }

    public void SetDifficultyLevel(int _difficultyLevel)
    {
        GameData.PlayerLives = GameData.PlayerLivesDifficulty[_difficultyLevel];
        GameData.MaxPlayerLives = GameData.MaxPlayerLivesDifficulty[_difficultyLevel];
        GameData.PlayerHP = GameData.PlayerHPDifficulty[_difficultyLevel];
        GameData.MaxPlayerHP = GameData.MaxPlayerHPDifficulty[_difficultyLevel];
        GameData.FireRateArray = GameData.FireRateArrayDifficulty[_difficultyLevel];
        GameData.BulletSpeedArray = GameData.BulletSpeedArrayDifficulty[_difficultyLevel];
        Debug.Log($"Difficulty set to {_difficultyLevel}");
    }

    // ENEMY CONFIG //
    private void FillBulletPrefabsArray()
    {
        for (int i = 1; i < GameData.BulletNamesArray.Length; i++)
        {
            LoadBulletPrefab(GameData.BulletNamesArray[i]);
            bulletPrefab.GetComponent<SpriteRenderer>().color = GameData.BulletColorsArray[i];
            GameData.BulletPrefabArray[i] = bulletPrefab;
        }
    }

    private void LoadBulletPrefab(string _prefabName)
    {
        bulletPrefab = Resources.Load($"Prefabs/{_prefabName}") as GameObject;
    }

    // STANDARD QUIT GAME CODE
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
    }
}