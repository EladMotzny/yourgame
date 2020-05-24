using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMove : MonoBehaviour
{

    [Tooltip("Change to increase/decrease movement speed")] [SerializeField] float moveSpeed = 4f;
    [Tooltip("Change to control left movement")] [SerializeField] KeyCode leftKey;
    [Tooltip("Change to control right movement")] [SerializeField] KeyCode rightKey;
    [Tooltip("Change to control left movement")] [SerializeField] KeyCode leftKey2;
    [Tooltip("Change to control right movement")] [SerializeField] KeyCode rightKey2;
    private bool direction; //false- right, true- left


    // Start is called before the first frame update
    void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey) || Input.GetKey(leftKey2))
        {
            if (!direction)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector3 movement = new Vector3(-1, 0, 0);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(rightKey) || Input.GetKey(rightKey2))
        {
            if (direction)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            transform.rotation = Quaternion.Euler(0, 180, 0);

            Vector3 movement = new Vector3(1, 0, 0);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }
}
