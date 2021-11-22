using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    private string btnName;
    public void SceneButton()
    {
        GameManager myGameManager = FindObjectOfType<GameManager>();
        btnName = this.name;
        myGameManager.ChangeScene(btnName);
    }

    public void DifficultyButton()
    {
        GameManager myGameManager = FindObjectOfType<GameManager>();
        char btnChar = this.name[this.name.Length - 1];
        int btnNo = btnChar - '0';
        Debug.Log(btnChar);
        Debug.Log(btnNo);
        myGameManager.SetDifficultyLevel(btnNo);
    }

    public void WeaponButton()
    {
        btnName = this.name;
        GameData.PlayerWeaponName = btnName;
        Debug.Log(GameData.PlayerWeaponName);
    }

    public void QuitButton()
    {
        GameManager myGameManager = FindObjectOfType<GameManager>();
        myGameManager.QuitGame();
    }
}