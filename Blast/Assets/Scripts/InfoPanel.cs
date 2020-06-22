using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{

    public Transform[] colors;

    public GameObject LeftInfoPanel;

    public GameObject RightInfoPanel;
    public Transform MolluNext;
    public Transform CheyNext;
    MolluShoot mollu;
    public int rand;


    // Start is called before the first frame update
    void Start()
    {

       // CheyNext = createNextLeftBubble();
        
        //MolluNext = createNextRightBubble();
        //mollu.CreateBubble(rand);

    }

    // Update is called once per frame
    void Update()
    {

       /* if (Input.GetKeyUp(GameManager.GM.RightPlayershoot))
        {
            Destroy(MolluNext.gameObject);
            MolluNext = createNextRightBubble();
           // mollu.CreateBubble(rand);
        }

        if (Input.GetKeyUp(GameManager.GM.LeftPlayershoot))
        {
            Destroy(CheyNext.gameObject);
            CheyNext = createNextLeftBubble();
        }*/


    }


   

   
}
