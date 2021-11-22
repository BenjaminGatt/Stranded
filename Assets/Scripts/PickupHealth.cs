using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickup
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.PlayerHP = GameData.MaxPlayerHP;
            myGameManager.DisplayHealth();
            Destroy(this.gameObject);
        }
    }
}