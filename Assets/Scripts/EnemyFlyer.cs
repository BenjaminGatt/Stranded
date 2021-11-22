using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyer : EnemyScript
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //Enemy stats
        enemyHP = 5;
        enemySpeed = 2f;
        enemyFireRate = 2f;
        bulletSpeed = 6f;
        deathScore = 15;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (GameData.RoomTrigger[triggerNumber] == true)
        {
            base.MoveToPlayer();
            base.Update();
        }
    }
}