using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    float moveSpeed = 2.5f;
    bool isMovingUp = true;

    void Update()
    {
        if (transform.position.y > -19f)
        {
            isMovingUp = false;
        }
        if (transform.position.y < -40f)
        {
            isMovingUp = true;
        }

        if (isMovingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}