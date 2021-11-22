using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //Damage of bullet
    protected int _bulletDamage = 1;

    //Bullet damage getter
    public int BulletDamage
    {
        get { return _bulletDamage; }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) //other contains a reference to the other collider it hits
    {
        if (other.gameObject.CompareTag("Terrain"))
            Destroy(this.gameObject);
    }
}