using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyScript
{
    Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    protected override void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyHP = 3;
        enemyFireRate = 2f;
        deathScore = 5;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        enemyRigidBody.velocity = new Vector2(enemySpeed, 0f);
        base.Update();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Bullet"))
        {
            enemySpeed = -enemySpeed;
        }
    }
}