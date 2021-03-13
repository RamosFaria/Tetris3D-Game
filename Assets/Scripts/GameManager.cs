using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int highScore;

    public static void Save()
    {
        PlayerPrefs.GetInt("highScore", highScore);
    }
    public static void Load()
    {
         PlayerPrefs.SetInt("highScore", highScore);
    }
}
