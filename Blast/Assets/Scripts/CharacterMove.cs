using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMove : MonoBehaviour
{

    [Tooltip("Change to increase/decrease movement speed")] [SerializeField] float moveSpeed = 4f;
    [Tooltip("Change red rocket launcher")] [SerializeField] GameObject redLauncher;
    [Tooltip("Change blue rocket launcher")] [SerializeField] GameObject blueLauncher;
    // [Tooltip("Change to control left movement")] [SerializeField] KeyCode leftKey;
    // [Tooltip("Change to control right movement")] [SerializeField] KeyCode rightKey;
    private bool LeftDirection; //false- right, true- left
    private bool RightDirection; //false- right, true- left
    //public GameObject LeftPlayer;
    //public GameObject RightPlayer;



    // Start is called before the first frame update
    void Start()
    {
        RightDirection = true;// the charcters always look at the left side at the beggining
        LeftDirection = true;
        //LeftPlayer = GetComponent<GameObject>();
       // RightPlayer = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(GameManager.GM.RightPlayerleft)) //going left- right character
        {
            if (this.CompareTag("Mollu"))
            {
                if (!getRightDirection())//check if flipping is needed
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);//face left
                    redLauncher.transform.rotation = Quaternion.Euler(0, 180, 90);//face left

                    setRightDirection(true);
                }

                Vector3 movement = new Vector3(-1, 0, 0);
                transform.position += movement * Time.deltaTime * moveSpeed;//move
            }
        }
        if (Input.GetKey(GameManager.GM.RightPlayerright))//going right- right character
        {
            if (this.CompareTag("Mollu")) {
               
                if (getRightDirection())//check if flipping is needed
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);//face right
                    redLauncher.transform.rotation = Quaternion.Euler(0, 0, 90);//face right
                    setRightDirection(false);
                }


                Vector3 movement = new Vector3(1, 0, 0);
                transform.position += movement * Time.deltaTime * moveSpeed;//move
            }
        }



        if (Input.GetKey(GameManager.GM.LeftPlayerleft)) //going left- left character
        {
            if (this.CompareTag("Chey"))
            {
                if (!getLeftDirection())//check if flipping is needed
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);//face left
                    blueLauncher.transform.rotation = Quaternion.Euler(0, 0, 90);
                    setLeftDirection(true);
                }

                Vector3 movement = new Vector3(-1, 0, 0);
                transform.position += movement * Time.deltaTime * moveSpeed;//move
            }
        }


        if (Input.GetKey(GameManager.GM.LeftPlayerright))//going right- left character
        {
            if (this.CompareTag("Chey"))
            {
                if (getLeftDirection())//check if flipping is needed
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);//face right
                    blueLauncher.transform.rotation = Quaternion.Euler(0, 180, 90);
                    setLeftDirection(false);
                }

                Vector3 movement = new Vector3(1, 0, 0);
                transform.position += movement * Time.deltaTime * moveSpeed;//move
            }
        }
    }


    public bool getLeftDirection()
    {
        Debug.Log("the direction is " + this.LeftDirection);
        return this.LeftDirection;
        
    }

    public void setLeftDirection(bool newDirection)
    {
        this.LeftDirection = newDirection;
    }

    public bool getRightDirection()
    {
        Debug.Log("the direction is " + this.RightDirection);
        return this.RightDirection;

    }

    public void setRightDirection(bool newDirection)
    {
        this.RightDirection = newDirection;
    }
}
