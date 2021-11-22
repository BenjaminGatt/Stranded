using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //This data is stored in binary form. Cannot be a monobehaviour
public class SerializedData
{
    public int serializedPlayerLives, serializedMaxPlayerLives, serializedPlayerHP, serializedMaxPlayerHP, serializedPlayerScore, serializedDifficultyLevel;
    public string serializedPlayerWeaponName;
    public int[] serializedHighScores;
    public string[] serializedBulletNamesArray;
    public float[] serializedFireRateArray, serializedBulletSpeedArray;

    // --- EASY DIFFICULTY ---
    //public int serializedPlayerLivesEasy, serializedMaxPlayerLivesEasy, serializedPlayerHPEasy, serializedMaxPlayerHPEasy;
    //public float[] serializedFireRateArrayEasy, serializedBulletSpeedArrayEasy;

    // --- MEDIUM DIFFICULTY --- */
    //public int serializedPlayerLivesMedium, serializedMaxPlayerLivesMedium, serializedPlayerHPMedium, serializedMaxPlayerHPMedium;
    //public float[] serializedFireRateArrayMedium, serializedBulletSpeedArrayMedium;

    ///* --- HARD DIFFICULTY --- */
    //public int serializedPlayerLivesHard, serializedMaxPlayerLivesHard, serializedPlayerHPHard, serializedMaxPlayerHPHard;
    //public float[] serializedFireRateArrayHard, serializedBulletSpeedArrayHard;
}