using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject[] prefabs;
    int clickCount = 0;
    [Tooltip("Typing speed")] [SerializeField] float typeSpeed = 0.02f;
    public GameObject continueButton;
    GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        instance = Instantiate(prefabs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (textDisplay.text == sentences[clickCount])//if true, sentence typing is done
        {
            continueButton.SetActive(true);//show the button again
        }
    }

    IEnumerator Type()//Type the first sentence in the textbox above booba
    {
        //isSpawned = true;
        foreach (char letter in sentences[clickCount].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);//print next letter after a certain ammount of time

        }
    }

    public void NextSentence()//type the next sentence after clicking continue
    {
        
        spawnPrefab(clickCount);


        continueButton.SetActive(false);//hide button while sentence is being typed

        if (clickCount < sentences.Length - 1)//check if the sentence is done
        {
            clickCount++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            //continueButton.SetActive(false);
        }
    }
    private void spawnPrefab(int clickCount)
    {
        switch (clickCount)
        {
            
            case 1:
                Debug.Log("Load ballBlue");
                Destroy(instance);
                instance = Instantiate(prefabs[1]);
                break;
            case 3:
                Debug.Log("Load CharControl");
                Destroy(instance);
                instance = Instantiate(prefabs[2]);
                break;
            case 5:
                Debug.Log("Load Against");
                Destroy(instance);
                instance = Instantiate(prefabs[3]);
                break;
            case 7:
                Debug.Log("Load Wall");
                Destroy(instance);
                instance = Instantiate(prefabs[4]);
                break;
            case 8:
                Debug.Log("Load Blackball");
                Destroy(instance);
                instance = Instantiate(prefabs[5]);
                break;
            case 9:
                Debug.Log("Load Lose");
                Destroy(instance);
                instance = Instantiate(prefabs[6]);
                break;
            case 11:
                Debug.Log("Load scene");
                welcomeScene();
                break;
        }
    }
    public void welcomeScene()
    {
        SceneManager.LoadScene("Welcome");
    }
}
