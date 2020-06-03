using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoToKeysConfigScene()
    {
        SceneManager.LoadScene("KeyMapping");
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToWelcome()
    {
        SceneManager.LoadScene("Welcome");
    }
}
