using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Enemy shooting
public class EnemyShoot : MonoBehaviour
{
    private GameObject player;
    private GameManager myGameManager;
    private Vector2 bulletDirection;
    private Coroutine enemyFire;
    private EnemyScript enemyScript;
    private GameObject bulletPrefab;
    private float fireRate, bulletSpeed;
    private Transform fireTransform;
    private string enemyType;


    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        player = myGameManager.FindPlayer();
        BulletData();
        ShootDirection();
        fireTransform = gameObject.transform.GetChild(0);
        enemyFire = StartCoroutine(Fire(bulletPrefab, fireRate, fireTransform, bulletSpeed));
    }

    private void Update()
    {
        ShootDirection();
    }

    private void BulletData()
    {
        enemyType = gameObject.tag;
        switch (enemyType)
        {
            case "Flyer":
                bulletPrefab = GameData.BulletPrefabArray[1];
                fireRate = GameData.FireRateArray[1];
                bulletSpeed = GameData.BulletSpeedArray[1];
                break;
            case "Turret":
                bulletPrefab = GameData.BulletPrefabArray[1];
                fireRate = GameData.FireRateArray[2];
                bulletSpeed = GameData.BulletSpeedArray[2];
                break;
            case "Walker":
                bulletPrefab = GameData.BulletPrefabArray[2];
                fireRate = GameData.FireRateArray[3];
                bulletSpeed = GameData.BulletSpeedArray[3];
                break;
        }
    }

    public void ShootDirection()
    {
        bulletDirection = player.transform.position - this.transform.position;
    }


    public virtual IEnumerator Fire(GameObject _bulletPrefab, float _waitTime, Transform _fireTransform, float _bulletSpeed/*, AudioClip _mySound*/)
    {
        while (true)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _fireTransform.position, Quaternion.identity) as GameObject;
            bulletDirection.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * _bulletSpeed;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
