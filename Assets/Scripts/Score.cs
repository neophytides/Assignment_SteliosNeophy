using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Score
{

    public static event EventHandler OnHighscoreChanged;

    private static int score;

    public static void InitializeStatic()
    {
        OnHighscoreChanged = null;
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    //Score increases when snake eats blue food
    public static void AddScoreBlue()
    {
        score += 20;
    }
    //Score increases when snake eats red food
    public static void AddScoreRed()
    {
        score += 10;
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighScore(score);
    }


    public static bool TrySetNewHighScore(int score)
    {
        int highscore = GetHighScore();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}
