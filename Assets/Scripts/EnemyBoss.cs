using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyScript
{
    protected override void Start()
    {
        
        //Enemy Stats
        enemyHP = 100;
        enemySpeed = 5f;
        enemyFireRate = 4f;
        bulletSpeed = 10f;
        deathScore = 100;
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

    protected override void EnemyDie()
    {
        if (enemyHP <= 0)
        {
            GameData.PlayerScore += deathScore;
            myGameManager.ProcessEndScore();
            myGameManager.DisplayScore();
            GameData.VictoryCondition = true;
            myGameManager.ChangeScene("EndScene");
        }
    }
}