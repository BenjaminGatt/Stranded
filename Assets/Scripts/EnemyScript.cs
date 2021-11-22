using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Enemy behaviour
public class EnemyScript : MonoBehaviour
{

    protected GameManager myGameManager;

    protected int enemyHP = 1;
    protected int deathScore = 10;
    protected float enemyFireRate = 1f;
    protected float enemySpeed = 3f;
    [SerializeField] protected Transform fireTransform;
    protected GameObject bulletPrefab;
    protected GameObject player;
    protected float bulletSpeed = 5f;
    protected float scaleX, scaleY, scaleZ;

    protected char thisTag;
    protected int triggerNumber;

    protected EnemyShoot myEnemyShoot;

    protected void Awake()
    {
        myGameManager = FindObjectOfType<GameManager>();
        player = myGameManager.FindPlayer();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        myEnemyShoot = FindObjectOfType<EnemyShoot>();
        thisTag = gameObject.tag[gameObject.tag.Length - 1];
        triggerNumber = thisTag - '0';
        scaleX = this.transform.localScale.x;
        scaleY = this.transform.localScale.y;
        scaleZ = this.transform.localScale.z;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FacePlayer();
        EnemyDie();
    }

    protected void FacePlayer()
    {
        if (player.transform.position.x >= this.transform.position.x)
        {
            this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            this.transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);
        }
    }

    protected virtual void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    protected virtual void EnemyDie()
    {
        if (enemyHP <= 0)
        {
            GameData.PlayerScore += deathScore;
            myGameManager.DisplayScore();
            Destroy(this.gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHP = enemyHP - other.GetComponent<Bullet>().BulletDamage;
            Destroy(other.gameObject);
        }
    }
}