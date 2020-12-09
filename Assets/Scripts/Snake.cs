using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class Snake : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    private enum Status
    {
        Alive,
        Dead
    }
    private Status status;
    private Direction gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;
    private int snakeBodySize;
    private List<SnakeMovePosition> snakeMovePositionList;
    private List<snakeBodyPart> snakeBody;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    
    private void Awake()
    {
        //Set the position of grid
        gridPosition = new Vector2Int(10, 10);
        //Set a timer to keep moving to direction
        gridMoveTimerMax = .3f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;

        //Set initial Body Size
        snakeMovePositionList = new List<SnakeMovePosition>();
        snakeBodySize = 0;

        //Initialize body sprite transformation
        snakeBody = new List<snakeBodyPart>();

        //Initial Status
        status = Status.Alive;
    }


    private void Update()
    {
        switch (status)
        {
            case Status.Alive:
                HandleInput();
                HandleGridMovement();
                break;
            case Status.Dead:
                //CMDebug.TextPopup("GAME OVER", transform.position);
                GameHandler.snakeDied();
                break;
        }
    }

    private void HandleInput()
    {
        //Move Up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //if not going down
            if (gridMoveDirection != Direction.Down)
            {
                gridMoveDirection = Direction.Up;
            }
        }

        //Move Down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //if not going up
            if (gridMoveDirection != Direction.Up)
            {
                gridMoveDirection = Direction.Down;
            }
        }
        //Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //if not going right
            if (gridMoveDirection != Direction.Right)
            {
                gridMoveDirection = Direction.Left;
            }
        }
        //Move right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //if not going left
            if (gridMoveDirection != Direction.Left)
            {
                gridMoveDirection = Direction.Right;
            }
        }
    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            

            SnakeMovePosition previousPosition = null;
            //at least one position in our list
            if (snakeMovePositionList.Count>0)
            {
                previousPosition = snakeMovePositionList[0] ;
            }
            
            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(previousPosition, gridPosition, gridMoveDirection);
            //Before snake's movement, insert the Position in the List.
            snakeMovePositionList.Insert(0, snakeMovePosition);

            //getting the direction vector
            Vector2Int directionVector;
            switch (gridMoveDirection)
            {
                default:
                case Direction.Right:   
                    directionVector = new Vector2Int(+1, 0);
                    break;
                case Direction.Left:    
                    directionVector = new Vector2Int(-1, 0); 
                    break;
                case Direction.Up:      
                    directionVector = new Vector2Int(0, +1); 
                    break;
                case Direction.Down:    
                    directionVector = new Vector2Int(0, -1); 
                    break;
            }
            //Move Snake on the grid
            gridPosition += directionVector;

            //Save the event of snake ate the food
            bool snakeAteFood = levelGrid.snakeEatFood(gridPosition);
            if (snakeAteFood)
            {
                //Grow
                snakeBodySize++;
                //Create body sprite
                createSnakeBody();
            }


            //Check list compared to snake body size
            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                //If the list is bigger than the body reduce it by 1
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            updateSnakeBody();

            //Collide with own body and game over
            foreach (snakeBodyPart part in snakeBody)
            {
                Vector2Int snakeBodyPartGridPosition = part.GetGridPosition();
                if (gridPosition == snakeBodyPartGridPosition)
                {
                    //GAME OVER
                    //Score pop up, ok button and redirect to the main menu

                    //Temporary
                    //CMDebug.TextPopup("DEAD", transform.position);
                    //Set status as dead
                    status = Status.Dead;
                    GameHandler.snakeDied();
                }
            }








            //Create the snake body
            /*
            for (int i=0;i<snakeMovePositionList.Count; i++)
            {
                Vector2Int snakeMovePosition = snakeMovePositionList[i];
                CodeMonkey.Utils.World_Sprite worldSprite = CodeMonkey.Utils.World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
                FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
            }
            */

            //make the snake rotate on turns (move properly)
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(directionVector) - 90);


            wallCollision();
        }

    }

    private void createSnakeBody()
    {
        snakeBody.Add(new snakeBodyPart(snakeBody.Count));
    }

    private void updateSnakeBody()
    {
        for (int i = 0; i < snakeBody.Count; i++)
        {
            snakeBody[i].SetSnakeMovePosition(snakeMovePositionList[i]);
        }
    }

    //Get the Angle
    private float getAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    //return the snake's full body (head included)
    public List<Vector2Int> getFullbody()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };
        foreach (SnakeMovePosition snakeMovePosition in snakeMovePositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }
        return gridPositionList;
    }

    //Handle each body part seperately
    private class snakeBodyPart
    {
        private SnakeMovePosition snkMove;
        private Transform transform;
        
        //a class that creates body parts instead of multiple creations
        public snakeBodyPart(int bodyIndex)
        {
            GameObject snakeBodyGameObject = new GameObject("body", typeof(SpriteRenderer));
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.snakeBodySprite;
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -1 -bodyIndex;
            transform = snakeBodyGameObject.transform;
        }

        public void SetSnakeMovePosition(SnakeMovePosition snkMove)
        {
            this.snkMove = snkMove;
            transform.position = new Vector3(snkMove.GetGridPosition().x, snkMove.GetGridPosition().y);


            float angle;
            //Checking initially the ongoing travel of the snake
            //the second switch checks the previous movement to control the angles and the rotation better
            switch (snkMove.GetDirection())
            {
                default:
                case Direction.Up:
                    switch (snkMove.GetPreviousDirection())
                    {
                        default:
                            angle = 0;
                            break;
                        case Direction.Left:
                            angle = 0 + 45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Right:
                            angle = 0 - 45;
                            transform.position += new Vector3(-.2f, .2f);
                            break;
                    }
                    break;
                case Direction.Down:
                    switch (snkMove.GetPreviousDirection())
                    {
                        default:
                            angle = 180;
                            break;
                        case Direction.Left:
                            angle = 180 - 45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                        case Direction.Right:
                            angle = 180 + 45;
                            transform.position += new Vector3(-.2f, -.2f);
                            break;
                    }
                    break;
                case Direction.Left:
                    switch (snkMove.GetPreviousDirection())
                    {
                        default:
                            angle = +90;
                            break;
                        case Direction.Down:
                            angle = 180 - 45;
                            transform.position += new Vector3(-.2f, .2f);
                            break;
                        case Direction.Up:
                            angle = 45;
                            transform.position += new Vector3(-.2f, -.2f);
                            break;
                    }
                    break;
                case Direction.Right:
                    switch (snkMove.GetPreviousDirection())
                    {
                        default:
                            angle = -90;
                            break;
                        case Direction.Down: // Previously was going Down
                            angle = 180 + 45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Up: // Previously was going Up
                            angle = -45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                    }
                    break;
            }
            transform.eulerAngles = new Vector3(0,0,angle);
        }
        
        public Vector2Int GetGridPosition()
        {
            return snkMove.GetGridPosition();
        }
        
    }
    //Handles one snake move position
    private class SnakeMovePosition
    {
        private SnakeMovePosition previousPosition;
        private Vector2Int gridPosition;
        private Direction direction;

        //constructor
        public SnakeMovePosition(SnakeMovePosition previousPosition,Vector2Int gridPosition, Direction direction)
        {
            this.previousPosition = previousPosition;
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        public Direction GetPreviousDirection()
        {
            //if null return a default
            if (previousPosition == null)
            {
                return Direction.Right;
            }
            else
            {
                return previousPosition.direction;
            }
        }
    }

    private void wallCollision()
    {
        if (gridPosition.x > levelGrid.GetWidth() || gridPosition.y > levelGrid.GetHeight()-1 || gridPosition.x < 0 || gridPosition.y < 1)
        {
            //hit the wall
            status = Status.Dead;
            GameHandler.snakeDied();
        }
    }
}