using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameAssets : MonoBehaviour
{

    public static GameAssets i;
    public static GameAssets t;

    private void Awake() {
        i = this;
        t = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite bluefoodSprite;
    public Sprite redfoodSprite;
    public Sprite snakeBodySprite;


}
