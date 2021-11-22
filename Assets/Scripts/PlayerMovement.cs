using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float playerRunSpeed = 7f;
    float playerJumpSpeed = 24f;
    float playerGravityScale = 0.3f;
    Rigidbody2D playerRigidBody;
    BoxCollider2D playerFeetCollider;
    Transform playerTransform;
    Animator playerAnimator;
    float playerDirectionX;
    Vector2 playerVelocity;
    bool isAlive = true;
    Transform playerWeapon;
    GameManager myGameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        playerTransform = this.GetComponent<Transform>();
        playerAnimator = this.GetComponent<Animator>();
        playerFeetCollider = this.GetComponent<BoxCollider2D>();
        myGameManager = FindObjectOfType<GameManager>();
        playerRigidBody.gravityScale = playerGravityScale;
        playerWeapon = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            PlayerRun();
            PlayerFlip();
            PlayerJump();
            PlayerAnimation();
            StartCoroutine(PlayerDie());
        }
        else
        {
            playerAnimator.SetBool("Running", false);
            playerAnimator.SetBool("Dead", true);
        }
    }   

    private void PlayerRun()
    {
        playerDirectionX = Input.GetAxis("Horizontal");
        playerVelocity = new Vector2((playerDirectionX*playerRunSpeed), playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpSpeed);
        }
    }

    private void PlayerFlip()
    {
        if (transform.position.x >= GameData.MouseTarget.x)
        {
            playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < GameData.MouseTarget.x)
        {
            playerTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    private IEnumerator PlayerDie()
    {
        if (GameData.PlayerHP <= 0)
        {
            isAlive = false;
            playerRigidBody.velocity = new Vector2(0f, 10f);
            Destroy(playerWeapon.gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(1f);
            myGameManager.ProcessPlayerDeath();
        }
    }

    private void PlayerAnimation()
    {
        if ((playerDirectionX != 0) && (playerVelocity.y > -1) && (playerVelocity.y < 1))
        {
            playerAnimator.SetBool("Running", true);
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && !this.gameObject.CompareTag("Terrain"))
        {
            GameData.PlayerHP -= other.GetComponent<Bullet>().BulletDamage;
            myGameManager.DisplayHealth();
            Destroy(other.gameObject);
        }    
    }
}