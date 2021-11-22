using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/SniperBullet") as GameObject;
        rateOfFire = 2.3f;
        bulletSpeed = 25f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}