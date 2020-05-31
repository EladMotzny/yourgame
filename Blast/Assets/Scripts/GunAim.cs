using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    [Tooltip("Rotation speed")] [SerializeField]  float rotateSpeed = 50f;
    [Tooltip("Launcher")] [SerializeField] GameObject rocketLauncher;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(GameManager.GM.LeftPlayerAimLeft))
        {
            this.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.GM.LeftPlayerAimRight))
        {
            transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
        }




        if (Input.GetKey(GameManager.GM.RightPlayerAimLeft))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.GM.RightPlayerAimRight))
        {
            transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
        }
    }
  
}
