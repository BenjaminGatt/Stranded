using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeapon : MonoBehaviour
{
    GameManager myGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        myGameManager.SetPlayerWeapon();
    }
}