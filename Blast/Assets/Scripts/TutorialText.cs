using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public Transform[] prefabs;
    int clickCount = 0;
    [Tooltip("Typing speed")] [SerializeField] float typeSpeed = 0.02f;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
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
        foreach (char letter in sentences[clickCount].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);//print next letter after a certain ammount of time

        }
    }

    public void NextSentence()//type the next sentence after clicking continue
    {

        //continueButton.SetActive(false);//hide button while sentence is being typed

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
}
