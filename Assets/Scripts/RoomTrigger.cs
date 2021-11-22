using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour
{
    private string triggerName;
    private char triggerChar;
    private int roomTriggerIndex;
    private GameManager myGameManager;
    private int currentSceneIndex;

    private void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        triggerName = gameObject.name;
        Debug.Log(triggerName);

        if (other.gameObject.CompareTag("Player") && triggerName != "LevelEnd")
        {
            triggerChar = triggerName[triggerName.Length - 1];
            roomTriggerIndex = triggerChar - '0';
            GameData.RoomTrigger[roomTriggerIndex] = true;
        }
        else if (other.gameObject.CompareTag("Player") && triggerName == "LevelEnd")
        {
            myGameManager.ChangeScene(currentSceneIndex + 1);
            GameData.RoomTrigger = new bool[]{ false, false, false, false, false };
        }
        else return;
    }
}