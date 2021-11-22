using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickup : MonoBehaviour
{
    protected Transform playerWeapon;
    protected string weaponName;
    protected GameManager myGameManager;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}