﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    //Create Keycodes that will be associated with each of our commands.
    //These can be accessed by any other script in our game
    public KeyCode RightPlayerleft { get; set; }
    public KeyCode RightPlayerright { get; set; }
    public KeyCode RightPlayershoot { get; set; }

    public KeyCode LeftPlayerleft { get; set; }
    public KeyCode LeftPlayerright { get; set; }
    public KeyCode LeftPlayershoot { get; set; }



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
        RightPlayershoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey1", "L"));//Changed from KeyPad0

        LeftPlayerleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey2", "A")); //assigns to a key code
        LeftPlayerright = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey2", "D"));
        LeftPlayershoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey2", "Space"));

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
