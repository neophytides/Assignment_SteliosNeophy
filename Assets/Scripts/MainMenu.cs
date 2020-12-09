using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button play;
    public Button highscore;
    public Button exit;

    public void toPlay()
    {
        //Move to Game Scene
            SceneManager.LoadScene(sceneName: "GameScene");
    }

    public void toExit()
    {
        //Exit to Desktop
        Application.Quit();
    }

    public void toScore()
    {
        //Show the highscore
        
    }
    
}
