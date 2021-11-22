using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : EnemyScript
{
    // Start is called before the first frame update
    protected override void Start()
    {
        enemyFireRate = 0.5f;
        enemyHP = 3;
        deathScore = 15;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}