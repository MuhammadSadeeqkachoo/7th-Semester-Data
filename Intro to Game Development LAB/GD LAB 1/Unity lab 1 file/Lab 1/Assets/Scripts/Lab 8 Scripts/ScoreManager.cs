using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int highscore = 0;

    public static void GameOver(int currentScore)
    {
        if (highscore < currentScore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            highscore = PlayerPrefs.GetInt("highscore");
        }
    }
}
