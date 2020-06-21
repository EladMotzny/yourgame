using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MolluShoot : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteMask forceSpriteMask;
    private float holdDownStartTime;//Time where you start holding the button down
    [Tooltip("Launcher")] [SerializeField] GameObject rocketLauncher;

    [Tooltip("Time to get to max force")] [SerializeField] float maxForceTime = 2f;
    [Tooltip("Maximum force to launch the missle at")] [SerializeField] float maxForce = 500f;
    bool shoot;
    public float speed = 0.05f;
    Transform bubble;
    Transform newBubble;
    public CircleCollider2D cd;
    public Transform[] colors;



    void Start()
    {
       shoot = false;

        CreateBubble();
        
        
       
    }

    void Update()
    {
        if (!shoot)
        {
            bubble.transform.position = rocketLauncher.transform.GetChild(0).position;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = rocketLauncher.transform.right * speed;
            Invoke("activateCollision", 1);
        }
        if (Input.GetKeyDown(GameManager.GM.RightPlayershoot))//Start charging
        {
            Debug.Log("Button down");
            holdDownStartTime = Time.time;
        }
        if (Input.GetKey(GameManager.GM.RightPlayershoot))//Mid charge
        {
            Debug.Log("charging...");
            float currHoldTime = Time.time - holdDownStartTime;

            //ShowForce(forceCalc(currHoldTime));
        }
        if (Input.GetKeyUp(GameManager.GM.RightPlayershoot) && !shoot)//End charge
        {
            shoot = true;
            float holdTime = Time.time - holdDownStartTime;
            Debug.Log("Button up");
            //send the calculated force to the shooting function with forceCalc here
            // var vec = new Vector3(10, 10,10); //x: float, y: float, z: float)
            // rb.AddForce(Vector2.up * 2); // , Impluse);

            Invoke("activateCollision", 1);
            Invoke("CreateBubble", 1);
            
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

    public void CreateBubble()
    {
        shoot = false;
        int rand = UnityEngine.Random.Range(0, 3);
        bubble = Instantiate(colors[rand], rocketLauncher.transform.GetChild(0).position, rocketLauncher.transform.GetChild(0).rotation);

        rb = bubble.GetComponent<Rigidbody2D>();

        cd = bubble.GetComponent<CircleCollider2D>();
        cd.enabled = false;

        bubble.position = rocketLauncher.transform.GetChild(0).position;


    }

    public void activateCollision()
    {
        cd.enabled = true;
    }
}


