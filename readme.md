======================================================
CLASSIC SNAKE 2D GAME
======================================================
Structure
------------------------------------------------------
MainMenu.cs
------------------------------------------------------
A file that contains all the proper actions by clicking Buttons.

I created three different public Buttons, i handle them through Unity
environment and the onClick functionality.
------------------------------------------------------
GameAssets.cs
------------------------------------------------------
Initializing all the needed game assets
------------------------------------------------------
GameHandler.cs
------------------------------------------------------
In this file i am handling the points and you will also see a small part from my try
to create the highscore functionality, as when i succeded the HighScore functionality, other functionality failed, 
so i decided to send this version, which is playable.
------------------------------------------------------
Snake.cs
------------------------------------------------------
Handling snake movement, rotation, growth, food, death and
controlling with Arrow Keys.
------------------------------------------------------
gameOverwindow.cs
------------------------------------------------------
Handling the Specification of the pop-up window when snake dies.
------------------------------------------------------
LevelGrid.cs
------------------------------------------------------
Food Spawning, Eating and destroying, passing Score respectively the type of food
to the processing class.
------------------------------------------------------
okcontroller.cs
------------------------------------------------------
Completing the action of OK Button.
------------------------------------------------------
ScoreWindows.cs
------------------------------------------------------
Showing the Score during the Game

======================================================
THE WAY
======================================================
I tried to use at most the objected oriented programming through C#, by creating classes and use them
to create childs of them so to not need much more source code and have an optimized and more readable and understandable
source code for the Evaluator.
----------------------------------------------------------------------------------------------------------------
THE PACKAGE
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
I used "Use and ReUse" as i used a package asset to get the graphics and create a much more beautiful GUI.
If the package was not available, i would try to create my own sprites in a fast way and use them.
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
DIDN'T SUCCEED TO DO
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
1. HighScore Specification
2. Streak Score Specification
*****Maybe with 5 more hours i am sure that i was able to do it as i had the code ready but not the time to integrate it with the rest of my source code.
=================================================================================================================
MORE ABOUT DESIGN
=================================================================================================================
1. FOR PASSING VARIABLES FROM CLASS TO CLASS SO TO USE THEM WITH ANY POSSIBLE AND NEEDED WAY
I USED PUBLIC VOID VARIABLES.

2. FOR HIGHSCORE SPECIFICATION I TRIED WITH PLAYER PREFS.

3. FOR SNAKE'S COLLISION, I APPROACH IT BY COMPARING THE PART OF GRID THE SNAKE WAS COVERING AND FOR THE
COLLISION WITH THE WALL I INITIATE LIMITS OF MY PLANE

4. I APPROACH THE GAME IN A 2D ENVIRONMENT TO REMEMBER US THE OLD GOOD CLASSIC SNAKE GAME

5. IN SNAKE'S MOVEMENT I USED THE GETKEYDOWN FUNCTION AND I ALSO CHECKED THE DIRECTIONS TO NOT LET THE SNAKE
DO MOVES THAT NOT DO IN REAL LIFE AND ALSO MOVES THAT WILL DRIVE TO A COLLISION

6. I USED EULER ANGLES TO MAKE THE SNAKE TURN

7. AND ALSO I APPROACH WITH A SIMILAR WAY WITH POINT 6 THE ROTATION OF THE BODY OF SNAKE WHEN MOVES.

8. THE IDEA THAT I WANTED TO IMPLEMENT FOR STREAK SCORE SPECIFICATION IT WAS:
	SAVE THE PREVIOUS EATEN FOOD IN A TEMP VARIABLE
	COMPARE IT WITH THE CURRENT EATEN FOOD
	KEEP A COUNTER FOR THE STREAK
	MULTIPLY THE STANDARD SCORE POINTS WITH THE COUNTER
	INCREASE THE SCORE
	PRINT/SHOW THE STREAK RECORD

9. FOR THE OK BUTTON AFTER SNAKE'S DEATH
	I CREATED A SHOW AND A HIDE FUNCTION
	A TEXT BOX AND THE BUTTON START AS HIDDEN
	WHEN THE SNAKE DIES
	SHOW FUNCTION TAKES ACTION

10. WITH MAIN MENU AND OKCONTROLLER I HANDLE THE ACTIONS OF EACH BUTTON
	THROUGH UNITY
	AND SOME SIMPLE CODE

11. "USE AND REUSE" AND OBJECT ORIENTED PROGRAMMING
==============================================================================================
LINK TO VIDEO
==============================================================================================
	https://we.tl/t-WzjCjoleGy
==============================================================================================
THANK YOU FOR THIS TREMENDOUS EXPERIENCE!!!
