using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    GameManager myGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        myGameManager.DisplayHealth();
        myGameManager.DisplayLives();
        myGameManager.DisplayScore();
        myGameManager.DisplayHighScores();
        myGameManager.DisplayWinLoss();
    }
}