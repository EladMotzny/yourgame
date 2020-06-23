using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public GameObject RightMenuPanel;

    public GameObject LeftMenuPanel;

    public GameObject txt;

    Event keyEvent;

    Text buttonText;

    KeyCode newKey;



    bool waitingForKey;


    void Start()

    {

        //Assign menuPanel to the Panel object in our Canvas

        //Make sure it's not active when the game starts

        //menuPanel = transform.FindChild("Panel");


        if ("Game" == SceneManager.GetActiveScene().name)
        {
            RightMenuPanel.gameObject.SetActive(false);
            LeftMenuPanel.gameObject.SetActive(false);
            
        }

        if ("KeyMapping" == SceneManager.GetActiveScene().name)
        {
            RightMenuPanel.gameObject.SetActive(true);
            LeftMenuPanel.gameObject.SetActive(true);
            txt.gameObject.SetActive(true);


        }

        waitingForKey = false;



        /*iterate through each child of the panel and check

         * the names of each one. Each if statement will

         * set each button's text component to display

         * the name of the key that is associated

         * with each command. Example: the LeftKey

         * button will display "A" in the middle of it

         */

        for (int i = 0; i < RightMenuPanel.transform.childCount; i++)

        {
            Transform child = RightMenuPanel.transform.GetChild(i);

            if (child.name == "LeftKey1")

                child.GetComponentInChildren<Text>().text = GameManager.GM.RightPlayerleft.ToString();

            else if (child.name == "RightKey1")

                child.GetComponentInChildren<Text>().text = GameManager.GM.RightPlayerright.ToString();

            else if (child.name == "shootKey1")

                child.GetComponentInChildren<Text>().text = GameManager.GM.RightPlayershoot.ToString();

            else if (child.name == "AimRightKey1")

                child.GetComponentInChildren<Text>().text = GameManager.GM.RightPlayerAimRight.ToString();

            else if (child.name == "AimLeftKey1")

                child.GetComponentInChildren<Text>().text = GameManager.GM.RightPlayerAimLeft.ToString();

        }

        for (int i = 0; i < LeftMenuPanel.transform.childCount; i++)

        {
            Transform child = LeftMenuPanel.transform.GetChild(i);

            if (child.name == "LeftKey2")

                child.GetComponentInChildren<Text>().text = GameManager.GM.LeftPlayerleft.ToString();

            else if (child.name == "RightKey2")

                child.GetComponentInChildren<Text>().text = GameManager.GM.LeftPlayerright.ToString();

            else if (child.name == "shootKey2")

                child.GetComponentInChildren<Text>().text = GameManager.GM.LeftPlayershoot.ToString();

            else if (child.name == "AimLeftKey2")

                child.GetComponentInChildren<Text>().text = GameManager.GM.LeftPlayerAimLeft.ToString();

            else if (child.name == "AimRightKey2")

                child.GetComponentInChildren<Text>().text = GameManager.GM.LeftPlayerAimRight.ToString();

        }

    }




    void Update()

    {

        if ("KeyMapping" == SceneManager.GetActiveScene().name)
        {
            //Escape key will open or close the panel

            if (Input.GetKeyDown(KeyCode.Escape) && !RightMenuPanel.gameObject.activeSelf && !LeftMenuPanel.gameObject.activeSelf)
            {
                txt.gameObject.SetActive(false);
                RightMenuPanel.gameObject.SetActive(true);
                LeftMenuPanel.gameObject.SetActive(true);
                

            }

            else if (Input.GetKeyDown(KeyCode.Escape) && RightMenuPanel.gameObject.activeSelf && LeftMenuPanel.gameObject.activeSelf)
            {

                RightMenuPanel.gameObject.SetActive(false);
                LeftMenuPanel.gameObject.SetActive(false);
                txt.gameObject.SetActive(true);


            }
        }

        if("Game" == SceneManager.GetActiveScene().name)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !RightMenuPanel.gameObject.activeSelf && !LeftMenuPanel.gameObject.activeSelf)
            {
                RightMenuPanel.gameObject.SetActive(true);
                LeftMenuPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                
                OnGUI();

            }

            else if (Input.GetKeyDown(KeyCode.Escape) && RightMenuPanel.gameObject.activeSelf && LeftMenuPanel.gameObject.activeSelf)
            {

                RightMenuPanel.gameObject.SetActive(false);
                LeftMenuPanel.gameObject.SetActive(false);
                Time.timeScale = 1;
                
            }
        }

    }


    void OnGUI()

    {

        /*keyEvent dictates what key our user presses

         * bt using Event.current to detect the current

         * event

         */

        keyEvent = Event.current;



        //Executes if a button gets pressed and

        //the user presses a key


        if (keyEvent.isKey && !waitingForKey)

        {

            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses

            waitingForKey = false;

            

        }

    }



    /*Buttons cannot call on Coroutines via OnClick().

     * Instead, we have it call StartAssignment, which will

     * call a coroutine in this script instead, only if we

     * are not already waiting for a key to be pressed.

     */

    public void StartAssignment(string keyName)

    {

        if (!waitingForKey)
        {

            StartCoroutine(AssignKey(keyName));
           
        }

    }



    //Assigns buttonText to the text component of

    //the button that was pressed

    public void SendText(Text text)

    {

        buttonText = text;
        Debug.Log("the button text is: " + text);

    }



    //Used for controlling the flow of our below Coroutine

    IEnumerator WaitForKey()

    {

        while (!keyEvent.isKey)

            yield return null;

    }



    /*AssignKey takes a keyName as a parameter. The

     * keyName is checked in a switch statement. Each

     * case assigns the command that keyName represents

     * to the new key that the user presses, which is grabbed

     * in the OnGUI() function, above.

     */

    public IEnumerator AssignKey(string keyName)

    {
        

        waitingForKey = true;



        yield return WaitForKey(); //Executes endlessly until user presses a key



        switch (keyName)

        {


            case "RightPlayerleft":

                GameManager.GM.RightPlayerleft = newKey; //set left to new keycode

                buttonText.text = GameManager.GM.RightPlayerleft.ToString(); //set button text to new key

                PlayerPrefs.SetString("LeftKey1", GameManager.GM.RightPlayerleft.ToString()); //save new key to playerprefs
                Debug.Log("LeftKey1 is " + GameManager.GM.RightPlayerleft.ToString());

                break;

            case "RightPlayerright":

                GameManager.GM.RightPlayerright = newKey; //set right to new keycode

                buttonText.text = GameManager.GM.RightPlayerright.ToString(); //set button text to new key

                PlayerPrefs.SetString("RightKey1", GameManager.GM.RightPlayerright.ToString()); //save new key to playerprefs
                Debug.Log("RightKey1 is " + GameManager.GM.RightPlayerright.ToString());

                break;

            case "RightPlayershoot":

                GameManager.GM.RightPlayershoot = newKey; //set jump to new keycode

                buttonText.text = GameManager.GM.RightPlayershoot.ToString(); //set button text to new key

                PlayerPrefs.SetString("shootKey1", GameManager.GM.RightPlayershoot.ToString()); //save new key to playerprefs
                Debug.Log("shootKey1 is " + GameManager.GM.RightPlayershoot.ToString());

                break;

            case "RightPlayerAimRight":

                GameManager.GM.RightPlayerAimRight= newKey; //set aim right to new keycode

                buttonText.text = GameManager.GM.RightPlayerAimRight.ToString(); //set button text to new key

                PlayerPrefs.SetString("AimRightKey1", GameManager.GM.RightPlayerAimRight.ToString()); //save new key to playerprefs
                Debug.Log("AimRightKey1 is " + GameManager.GM.RightPlayerAimRight.ToString());

                break;

            case "RightPlayerAimLeft":

                GameManager.GM.RightPlayerAimLeft = newKey; //set aim left to new keycode

                buttonText.text = GameManager.GM.RightPlayerAimLeft.ToString(); //set button text to new key

                PlayerPrefs.SetString("AimLeftKey1", GameManager.GM.RightPlayerAimLeft.ToString()); //save new key to playerprefs
                Debug.Log("AimLeftKey1 is " + GameManager.GM.RightPlayerAimLeft.ToString());

                break;


            case "LeftPlayerleft":

                GameManager.GM.LeftPlayerleft = newKey; //set left to new keycode

                buttonText.text = GameManager.GM.LeftPlayerleft.ToString(); //set button text to new key

                PlayerPrefs.SetString("LeftKey2", GameManager.GM.LeftPlayerleft.ToString()); //save new key to playerprefs
                Debug.Log("LeftKey2 is " + GameManager.GM.LeftPlayerleft.ToString());

                break;

            case "LeftPlayerright":

                GameManager.GM.LeftPlayerright = newKey; //set right to new keycode

                buttonText.text = GameManager.GM.LeftPlayerright.ToString(); //set button text to new key

                PlayerPrefs.SetString("RightKey2", GameManager.GM.LeftPlayerright.ToString()); //save new key to playerprefs
                Debug.Log("RightKey2 is " + GameManager.GM.LeftPlayerright.ToString());

                break;

            case "LeftPlayershoot":

                GameManager.GM.LeftPlayershoot = newKey; //set jump to new keycode

                buttonText.text = GameManager.GM.LeftPlayershoot.ToString(); //set button text to new key

                PlayerPrefs.SetString("shootKey2", GameManager.GM.LeftPlayershoot.ToString()); //save new key to playerprefs
                Debug.Log("shootKey2 is " + GameManager.GM.LeftPlayershoot.ToString());

                break;

            case "LeftPlayerAimRight":

                GameManager.GM.LeftPlayerAimRight= newKey; //set aim right to new keycode

                buttonText.text = GameManager.GM.LeftPlayerAimRight.ToString(); //set button text to new key

                PlayerPrefs.SetString("AimRightKey2", GameManager.GM.LeftPlayerAimRight.ToString()); //save new key to playerprefs
                Debug.Log("AimRightKey2 is " + GameManager.GM.LeftPlayerAimRight.ToString());

                break;

            case "LeftPlayerAimLeft":

                GameManager.GM.LeftPlayerAimLeft = newKey; //set aim left to new keycode

                buttonText.text = GameManager.GM.LeftPlayerAimLeft.ToString(); //set button text to new key

                PlayerPrefs.SetString("AimLeftKey2", GameManager.GM.LeftPlayerAimLeft.ToString()); //save new key to playerprefs
                Debug.Log("AimLeftKey2 is " + GameManager.GM.LeftPlayerAimLeft.ToString());

                break;

        }



        yield return null;

    }

}
