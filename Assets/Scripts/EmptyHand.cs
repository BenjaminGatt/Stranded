using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The default weapon equipped for the player if no weapon is selected. Used mainly during debugging.
public class EmptyHand : PlayerWeapon
{
    // Update is called once per frame
    protected override void Update()
    {
        ShootDirection();
        RotateWeapon();
    }
}