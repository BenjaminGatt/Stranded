using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/ShotgunShell") as GameObject;
        rateOfFire = 1.7f;
        bulletSpeed = 10f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator Fire(GameObject _bulletPrefab, float _waitTime, float _bulletSpeed/*, AudioClip _mySound*/)
    {
        while (true)
        {
            fireTransform = this.gameObject.transform.GetChild(0);
            GameObject bullet1 = Instantiate(_bulletPrefab, fireTransform.position, Quaternion.identity) as GameObject;
            bulletDirection.Normalize();
            bullet1.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;

            GameObject bullet2 = Instantiate(_bulletPrefab, fireTransform.position, Quaternion.identity) as GameObject;
            
            bulletDirection.y += 0.1f;
            bulletDirection.Normalize();
            bullet2.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;

            GameObject bullet3 = Instantiate(_bulletPrefab, fireTransform.position, Quaternion.identity) as GameObject;
            bulletDirection.y -= 0.2f;
            bulletDirection.Normalize();
            bullet3.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}