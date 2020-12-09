using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid 
{
    private Vector2Int foodGridPosition;
    private GameObject bluefoodGameObject;
    private GameObject redfoodGameObject;
    private int width;
    private int height;
    private Snake snake;
    public static int bonus;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
   
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;

        spawnFood();
    }

    public int GetHeight()
    {
        return this.height;
    }
    public int GetWidth()
    {
        return this.width;
    }

    private void spawnFood()
    {
        float randomChance = Random.Range(0.0f, 2.0f);
        //As the snake reach to the same position with food in the grid spawn a new one
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width-2), Random.Range(0, height-2));
        } while (snake.getFullbody().IndexOf(foodGridPosition) != -1);
        if (randomChance < 0.4f)
        {
            bluefoodGameObject = new GameObject("bluefood", typeof(SpriteRenderer));
            bluefoodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.bluefoodSprite;
            bluefoodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
        }
        else
        {
            redfoodGameObject = new GameObject("redfood", typeof(SpriteRenderer));
            redfoodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.t.redfoodSprite;
            redfoodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
        }
    }
    public int blueCounter;
    public int redCounter;
    public bool previousEaten;
    //check if snake Eat Food and return true else return false
    public bool snakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition && bluefoodGameObject)
        {
            Object.Destroy(bluefoodGameObject);
            previousEaten = true;
            spawnFood();
            GameHandler.AddScoreBlue();
            blueCounter = blueCounter + 1;
            return true;
        }
        else if (snakeGridPosition == foodGridPosition && redfoodGameObject)
        {
            Object.Destroy(redfoodGameObject);
            previousEaten = true;
            spawnFood();
            GameHandler.AddScoreRed();
            redCounter = blueCounter + 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
