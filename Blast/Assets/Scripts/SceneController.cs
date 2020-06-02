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
        SceneManager.LoadScene("KeysConfig");
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
