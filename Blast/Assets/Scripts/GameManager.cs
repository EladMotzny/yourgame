using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    //Create Keycodes that will be associated with each of our commands.
    //These can be accessed by any other script in our game
    public KeyCode RightPlayerleft { get; set; }
    public KeyCode RightPlayerright { get; set; }
    public KeyCode RightPlayershoot { get; set; }
    public KeyCode RightPlayerAimRight { get; set; }
    public KeyCode RightPlayerAimLeft { get; set; }


    public KeyCode LeftPlayerleft { get; set; }
    public KeyCode LeftPlayerright { get; set; }
    public KeyCode LeftPlayershoot { get; set; }
    public KeyCode LeftPlayerAimRight { get; set; }
    public KeyCode LeftPlayerAimLeft { get; set; }

    public int numberOfBubblesRight;
    public int numberOfBubblesLeft;
    public Transform[] levelsRight;
    public Transform[] levelsLeft;
    public int currentLevelIndexRight;
    public int currentLevelIndexLeft;
    public int scoreLeft;
    public int scoreRight;



    void Awake()//assign gm
    {
        
        //Singleton pattern
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
                Destroy(gameObject);   
        }
        
        
        

        /*Assign each keycode when the game starts.
         * Loads data from PlayerPrefs so if a user quits the game,
         * their bindings are loaded next time. Default values
         * are assigned to each Keycode via the second parameter
         * of the GetString() function
         */
        RightPlayerleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey1", "LeftArrow")); //assigns to a key code
        RightPlayerright = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey1", "RightArrow"));
        RightPlayershoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey1", "Space"));//Changed from KeyPad0
        RightPlayerAimLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AimLeft1", "UpArrow"));
        RightPlayerAimRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AimRight1", "DownArrow"));

        LeftPlayerleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey2", "A")); //assigns to a key code
        LeftPlayerright = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey2", "D"));
        LeftPlayershoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey2", "LeftControl"));
        LeftPlayerAimLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AimLeft2", "W"));
        LeftPlayerAimRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AimRight2", "S"));

    }
    
    void Start()
    {
        numberOfBubblesLeft = levelsLeft[0].transform.childCount;
        Debug.Log("number of bubbles in left: " + numberOfBubblesLeft);
        numberOfBubblesRight = levelsRight[0].transform.childCount;
        Debug.Log("number of bubbles in right: " + numberOfBubblesRight);
        currentLevelIndexLeft = 0;


    }

    void Update()
    {

    }

    //Will be called when a hit is detected. Score will be updated according to if the player hit the other player or a bubble
    public void updateScoreLeft(int score)
    {
        scoreLeft += score;
    }

    //Will get called when a ball on the left side is hit
    public void updateNumberOfBubblesLeft(int change)
    {
        numberOfBubblesLeft+= change;
        //check if the game is over
        if(numberOfBubblesLeft <= 0)
        {
            if(currentLevelIndexLeft <= levelsLeft.Length - 1)
            {
                //left player win, change to left player win scene
            }
            else
            {
                //there are still levels left, load the next one
                Debug.Log("Change level");
                LoadLevelLeft();
            }
        }
    }

    void LoadLevelLeft()
    {
        currentLevelIndexLeft++;
        Instantiate(levelsLeft[currentLevelIndexLeft], Vector2.zero, Quaternion.identity);
        numberOfBubblesLeft = levelsLeft[currentLevelIndexLeft].transform.childCount;

    }




    public void updateNumberOfBubblesRight(int change)
    {

        Debug.Log("change= " + change);
        if (change == 1)
        {
            numberOfBubblesRight++;
        }
        else if (change== -1)
        {
            numberOfBubblesRight--;
        }

        Debug.Log("right amount of bubbles= " + numberOfBubblesRight);
        //check if the game is over
        if (numberOfBubblesRight <= 0)
        {
            if (currentLevelIndexRight <= levelsRight.Length - 1)
            {
                //left player win, change to left player win scene
            }
            else
            {
                //there are still levels left, load the next one
                LoadLevelRight();
            }
        }
    }


    void LoadLevelRight()
    {
        currentLevelIndexRight++;
        Instantiate(levelsRight[currentLevelIndexRight], Vector2.zero, Quaternion.identity);
        numberOfBubblesRight = levelsRight[currentLevelIndexRight].transform.childCount;
    }
    public void updateScoreRight(int score)
    {
        scoreRight += score;
    }

    public bool checkFreeBubbles(int color)
    {
        

        Debug.Log("color= " + levelsRight[0].transform.childCount);
        Transform level = levelsRight[currentLevelIndexRight];
       
        int count = 0;

        for (int i = 0; i < level.childCount; i++)

        {
            Transform child = level.GetChild(i);
            if(child.CompareTag("RedBall") && color==0)
            {
                Debug.Log("I am in");
                count++;
            }
            if (child.CompareTag("BlueBall") && color == 1)
            {
                count++;
            }
            if (child.CompareTag("GreenBall") && color == 2)
            {
                count++;
            }
            if (child.CompareTag("YellowBall") && color == 3)
            {
                count++;
            }

        }

        Debug.Log("count= " + count);
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

               
    }
    
}
