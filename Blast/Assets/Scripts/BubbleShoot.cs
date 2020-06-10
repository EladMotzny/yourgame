using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShoot : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteMask forceSpriteMask;
    private float holdDownStartTime;//Time where you start holding the button down
    [Tooltip("Launcher")] [SerializeField] GameObject rocketLauncher;

    [Tooltip("Time to get to max force")] [SerializeField] float maxForceTime = 2f;
    [Tooltip("Maximum force to launch the missle at")] [SerializeField] float maxForce = 500f;



    void Start()
    {
       
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.position = rocketLauncher.transform.GetChild(0).position;
       

        if (Input.GetKeyDown(GameManager.GM.RightPlayershoot) || Input.GetKeyDown(GameManager.GM.LeftPlayershoot))//Start charging
        {
            Debug.Log("Button down");
            holdDownStartTime = Time.time;
        }
        if (Input.GetKey(GameManager.GM.RightPlayershoot) || Input.GetKeyDown(GameManager.GM.LeftPlayershoot))//Mid charge
        {
            Debug.Log("charging...");
            float currHoldTime = Time.time - holdDownStartTime;
            //ShowForce(forceCalc(currHoldTime));
        }
        if (Input.GetKeyUp(GameManager.GM.RightPlayershoot) || Input.GetKeyUp(GameManager.GM.LeftPlayershoot))//End charge
        {
            float holdTime = Time.time - holdDownStartTime;
            Debug.Log("Button up");
            //send the calculated force to the shooting function with forceCalc here

            var vec = new Vector3(10, 10, 0); //x: float, y: float, z: float)
            rb.AddForce(vec); // , Impluse);


        }
    }



    private float forceCalc(float holdTime)
    {
        float force = Mathf.Clamp01(holdTime / maxForceTime) * maxForce;
        return force;

    }

    private void HideForce()
    {
        forceSpriteMask.alphaCutoff = 1;
    }

    public void ShowForce(float force)
    {
        forceSpriteMask.alphaCutoff = 1 - force / maxForce;
    }
}


