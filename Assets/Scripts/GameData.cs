using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class GameData : MonoBehaviour
{
    //Default player stats
    private static int
        playerLives = 3,
        maxPlayerLives = 3,
        playerHP = 100,
        maxPlayerHP = 100,
        playerScore = 0,
        difficultyLevel = 0;

    //Values for Easy, Medium, and Hard difficulty settings
    private static int[]
        playerHighScores = new int[] { 0, 0, 0, 0, 0 },
        playerLivesDifficulty = new int[] { 3, 2, 1 },
        maxPlayerLivesDifficulty = new int[] { 3, 2, 1 },
        playerHPDifficulty = new int[] { 100, 75, 50 },
        maxPlayerHPDifficulty = new int[] { 100, 75, 50 };

    //Allows enemies to begin moving towards the player only when a trigger occurs
    private static bool[] roomTrigger = new bool[] { false, false, false, false, false };
    //Player's weapon
    private static string playerWeaponName = "EmptyHand";
    //Has the player killed the boss?
    private static bool victoryCondition = false;

    // Enemy Data //    
    private static string[] bulletNames = new string[] { "DefaultBullet", "SmallBullet", "WalkerBullet", "RifleBullet", "ShotgunShell", "SniperBullet" };
    private static Color[] bulletColors = new Color[] { Color.white, Color.red, Color.red, Color.white, Color.white, Color.white };
    private static GameObject[] bulletPrefabArray = new GameObject[bulletNames.Length];
    
    //Default enemy fire rate and bullet speed
    private static float[]
        fireRateArray = new float[] { 0.6f, 0.5f, 0.4f, 0.5f },
        bulletSpeedArray = new float[] { 5f, 10f, 15f, 10f };

    //Enemy fire rate and bullet speed depending on difficulty
    private static float[][]
        fireRateArrayDifficulty =
        {
            new float[] { 0.6f, 0.5f, 0.4f, 0.5f },
            new float[] { 0.5f, 0.4f, 0.3f, 0.4f },
            new float[] { 0.4f, 0.3f, 0.2f, 0.3f }
        },
        bulletSpeedArrayDifficulty =
        {
            new float[] { 5f, 10f, 15f, 10f },
            new float[] { 8f, 13f, 18f, 13f },
            new float[] { 10f, 15f, 20f, 15f }
        };

    public static GameObject FindPlayerObject
    {
        get { return GameObject.Find("Player"); }
    }

    public static int DifficultyLevel
    {
        get { return difficultyLevel; }
        set { difficultyLevel = value; }
    }

    public static int PlayerLives
    {
        get { return playerLives; }
        set { playerLives = value;  }
    }

    public static int MaxPlayerLives
    {
        get { return maxPlayerLives; }
        set { maxPlayerLives = value; }
    }

    public static int[] PlayerLivesDifficulty
    {
        get { return playerLivesDifficulty; }
    }

    public static int[] MaxPlayerLivesDifficulty
    {
        get { return maxPlayerLivesDifficulty; }
    }

    public static int PlayerHP
    {
        get { return playerHP; }
        set { playerHP = value; }
    }

    public static int MaxPlayerHP
    {
        get { return maxPlayerHP; }
        set { maxPlayerHP = value; }
    }

    public static int[] PlayerHPDifficulty
    {
        get { return playerHPDifficulty; }
    }

    public static int[] MaxPlayerHPDifficulty
    {
        get { return maxPlayerHPDifficulty; }
    }

    public static int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public static int[] PlayerHighScores
    {
        get { return playerHighScores; }
        set { playerHighScores = value; }
    }

    public static bool[] RoomTrigger
    {
        get { return roomTrigger;  }
        set { roomTrigger = value;  }
    }
    
    public static string PlayerWeaponName
    {
        get { return playerWeaponName; }
        set { playerWeaponName = value; }
    }

    public static GameObject[] BulletPrefabArray
    {
        get { return bulletPrefabArray; }
        set { bulletPrefabArray = value; }
    }

    public static string[] BulletNamesArray
    {
        get { return bulletNames; }
        set { bulletNames = value; }
    }

    public static float[] FireRateArray
    {
        get { return fireRateArray; }
        set { fireRateArray = value; }
    }

    public static float[][] FireRateArrayDifficulty
    {
        get { return fireRateArrayDifficulty; }
    }

    public static float[] BulletSpeedArray
    {
        get { return bulletSpeedArray; }
        set { bulletSpeedArray = value; }
    }

    public static float[][] BulletSpeedArrayDifficulty
    {
        get { return bulletSpeedArrayDifficulty; }
    }

    public static Color[] BulletColorsArray
    {
        get { return bulletColors; }
        set { bulletColors = value; }
    }

    public static bool VictoryCondition
    {
        get { return victoryCondition; }
        set { victoryCondition = value; }
    }

    public static Vector3 MouseTarget //No brackets after MouseTarget. It is not a method but a property.
    {
        get { return GetTarget(); }
    }

    private static Vector3 GetTarget()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        return mousePos;
    }

    public static float XMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x; }
    }
    public static float XMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x; }
    }
    public static float YMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y; }
    }
    public static float YMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y; }
    }
}