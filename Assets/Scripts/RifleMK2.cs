using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMK2 : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/RifleBullet") as GameObject;
        UpgradedBulletColor();
        rateOfFire = 0.05f;
        bulletSpeed = 20f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}