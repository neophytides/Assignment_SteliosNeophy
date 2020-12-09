using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class gameOverwindow : MonoBehaviour
{
    private static gameOverwindow instance;

    private Button bb;
    
    //bb = GameObject.Find("ok").GetComponent<UnityEngine.UI.Button>();
    
    
    
    public Text lastScore;
    

    private void Awake()
    {
        instance = this;
        lastScore = transform.Find("lastScore").GetComponent<Text>();
        bb = transform.Find("ok").GetComponent<Button>();

        Hide();
    }

    private void Update()
    {
        lastScore.text = GameHandler.GetScore().ToString();
    }

    private void Show()
    {
        bb.gameObject.SetActive(true);
        lastScore.gameObject.SetActive(true);
    }

    private void Hide()
    {
        bb.gameObject.SetActive(false);
        lastScore.gameObject.SetActive(false);
    }

    public static void showStatic()
    {
        instance.Show();
    }
}
