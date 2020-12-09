using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class okcontroller : MonoBehaviour
{

    public Button okk;
    public void toOK()
    {
        //Move to Main Scene
        SceneManager.LoadScene(sceneName: "MainScene");
    }
}
