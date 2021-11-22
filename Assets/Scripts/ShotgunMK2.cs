using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMK2 : PlayerWeapon
{
    // Start is called before the first frame update
    protected void Start()
    {
        bulletPrefab = Resources.Load("Prefabs/ShotgunShell") as GameObject;
        UpgradedBulletColor();

        rateOfFire = 1f;
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
            for (int i = 0; i < 2; i++)
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

                GameObject bullet4 = Instantiate(_bulletPrefab, fireTransform.position, Quaternion.identity) as GameObject;
                bulletDirection.y += 0.2f;
                bulletDirection.Normalize();
                bullet4.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;

                GameObject bullet5 = Instantiate(_bulletPrefab, fireTransform.position, Quaternion.identity) as GameObject;
                bulletDirection.y -= 0.3f;
                bulletDirection.Normalize();
                bullet5.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(_waitTime);
        }
    }
}