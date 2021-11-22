using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/RifleBullet") as GameObject;
        rateOfFire = 0.2f;
        bulletSpeed = 10f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}