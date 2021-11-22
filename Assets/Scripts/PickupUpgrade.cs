using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUpgrade : Pickup
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.PlayerWeaponName += "MK2";
            myGameManager.SetPlayerWeapon();
            Destroy(this.gameObject);
        }
    }
}