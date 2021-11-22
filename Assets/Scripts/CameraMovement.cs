using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Camera follows player
public class CameraMovement : MonoBehaviour
{

    private GameObject myPlayer;
    GameManager myGameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        myPlayer = myGameManager.FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        myPlayer = myGameManager.FindPlayer();
        Vector2 newCamPos = new Vector2(myPlayer.transform.position.x, myPlayer.transform.position.y);
        transform.position = new Vector3(newCamPos.x, newCamPos.y, transform.position.z);
    }
}