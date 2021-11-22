using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMK2 : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/SniperBullet") as GameObject;
        rateOfFire = 1f;
        bulletSpeed = 25f;
        UpgradedBulletColor();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}