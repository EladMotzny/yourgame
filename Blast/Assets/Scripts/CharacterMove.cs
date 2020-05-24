using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMove : MonoBehaviour
{

    [Tooltip("Change to increase/decrease movement speed")] [SerializeField] float moveSpeed = 4f;
    [Tooltip("Change to control left movement")] [SerializeField] KeyCode leftKey;
    [Tooltip("Change to control right movement")] [SerializeField] KeyCode rightKey;
    private bool direction; //false- right, true- left


    // Start is called before the first frame update
    void Start()
    {
        direction = true;// the charcters always look at the left side at the beggining
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey)) //going left- both characters
        {
            if (!getDirection())//check if flipping is needed
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);//face left
                setDirection(true);
            }

            Vector3 movement = new Vector3(-1, 0, 0);
            transform.position += movement * Time.deltaTime * moveSpeed;//move
        }
        if (Input.GetKey(rightKey))//going right- both charachters
        {
            if (getDirection())//check if flipping is needed
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);//face right
                setDirection(false);
            }

            Vector3 movement = new Vector3(1, 0, 0);
            transform.position += movement * Time.deltaTime * moveSpeed;//move
        }
    }


    public bool getDirection()
    {
        Debug.Log("the direction is " + this.direction);
        return this.direction;
        
    }

    public void setDirection(bool newDirection)
    {
        this.direction = newDirection;
    }
}
