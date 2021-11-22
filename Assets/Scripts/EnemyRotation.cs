using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Used for enemy gun rotation
public class EnemyRotation : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameData.FindPlayerObject;
    }

    // Update is called once per frame
    void Update()
    {
        FixedRotation();
    }

    protected Quaternion FixedRotation()
    {
        Quaternion enemyRotation = Quaternion.LookRotation(player.transform.position - this.transform.position, Vector3.up);
        enemyRotation.x = 0f;
        enemyRotation.y = 0f;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, enemyRotation, Time.deltaTime * 4);
        return enemyRotation;
    }
}