using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    private void Awake()
    {
        

        scoreText = transform.Find("scoreText").GetComponent<Text>();

        
    }
    
    //public highscore == 0;
    
    private void Update()
    {
        scoreText.text = GameHandler.GetScore().ToString();

        //if (scoreText > highscore) ;
        //highscore = score;
        //text.text = "" + score;

        //PlayerPrefs.SetInt("highscore", scoreText);
        //PlayerPrefs.Save();
    }
}
