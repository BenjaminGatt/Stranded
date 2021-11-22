using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShell : Bullet
{
    void Start()
    {
        _bulletDamage = 1;
    }
    protected override void OnTriggerEnter2D(Collider2D other) //other is the variable name which will contain a reference to the other collider we want it to interact with
    {
        if (other.gameObject.CompareTag("Terrain")) //tags can group different game objects with the same tag. tags can be created in the inspector.
            Destroy(this.gameObject);
        else if (other.gameObject.CompareTag("Bullet"))
            Destroy(other.gameObject);
    }
}