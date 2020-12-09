using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {
    private static GameHandler instance;
    private static int score;
    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;

        //PlayerPrefs.SetInt("highscore", 100);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("highscore"));
    }

    private void Start() {
        Debug.Log("GameHandler.Start");

        //GameObject snakeHeadGameObject = new GameObject();
        //SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        //snakeSpriteRenderer.sprite = GameAssets.i.snakeHeadSprite;

        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
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

    public static void snakeDied()
    {
        gameOverwindow.showStatic();
    }
}
