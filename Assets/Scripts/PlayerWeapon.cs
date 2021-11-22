using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    protected GameManager myGameManager;
    protected Transform fireTransform;
    protected float rateOfFire = 1f;
    protected float bulletSpeed = 5f;
    protected Vector2 bulletDirection;
    protected GameObject player, bulletPrefab, weaponPrefab, playerWeapon;
    protected Coroutine playerShoot;
    protected Vector3 mousePos;
    protected SpriteRenderer upgradedBullet;

    protected bool cooldown = false;


    protected void Awake()
    {
        myGameManager = FindObjectOfType<GameManager>();
        player = myGameManager.FindPlayer();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ShootDirection();
        RotateWeapon();
        PlayerShoot();
    }

    protected void ShootDirection()
    {
        bulletDirection = mousePos - this.transform.position;
    }

    protected void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1") && cooldown == false)
        {
            playerShoot = StartCoroutine(Fire(bulletPrefab, rateOfFire, bulletSpeed));
            Invoke("ResetCooldown", rateOfFire);
            cooldown = true;
        }
        else if (Input.GetButtonUp("Fire1") && (playerShoot != null))
        {
            StopCoroutine(playerShoot);
        }
    }

    protected void ResetCooldown()
    {
        cooldown = false;
    }

    protected void UpgradedBulletColor()
    {
        upgradedBullet = bulletPrefab.GetComponent<SpriteRenderer>();
        upgradedBullet.color = Color.cyan;
    }

    protected Quaternion RotateWeapon()
    {
        mousePos = GameData.MouseTarget;
        Quaternion weaponRotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.up); //Vector3.up is shorthand for writing Vector3(0,1,0)
        weaponRotation.x = 0f;
        weaponRotation.y = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, weaponRotation, Time.deltaTime * 4);
        return weaponRotation;
    }

    protected virtual IEnumerator Fire(GameObject _bulletPrefab, float _waitTime, float _bulletSpeed/*, AudioClip _mySound*/)
    {
        while (true)
        {
            fireTransform = this.gameObject.transform.GetChild(0);
            GameObject bullet = Instantiate(_bulletPrefab, fireTransform.position, transform.rotation) as GameObject;
            bulletDirection.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}