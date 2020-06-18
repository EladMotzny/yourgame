using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheyShoot : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteMask forceSpriteMask;
    private float holdDownStartTime;//Time where you start holding the button down
    [Tooltip("Launcher")] [SerializeField] GameObject rocketLauncher;

    [Tooltip("Time to get to max force")] [SerializeField] float maxForceTime = 2f;
    [Tooltip("Maximum force to launch the missle at")] [SerializeField] float maxForce = 500f;
    bool shoot;
    public float speed = 0.05f;
    public Transform bubble;
    Transform newBubble;
    public CircleCollider2D cd;



    void Start()
    {
       shoot = false;

        rb = bubble.GetComponent<Rigidbody2D>();
   
        cd = bubble.GetComponent<CircleCollider2D>();
        cd.enabled = false;

        bubble.position = rocketLauncher.transform.GetChild(0).position;
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
        if (Input.GetKeyDown(GameManager.GM.LeftPlayershoot))//Start charging
        {
            Debug.Log("Button down");
            holdDownStartTime = Time.time;
        }
        if (Input.GetKey(GameManager.GM.LeftPlayershoot))//Mid charge
        {
            Debug.Log("charging...");
            float currHoldTime = Time.time - holdDownStartTime;

            //ShowForce(forceCalc(currHoldTime));
        }
        if (Input.GetKeyUp(GameManager.GM.LeftPlayershoot))//End charge
        {
            // Cheyshoot = true;
            shoot = true;
            float holdTime = Time.time - holdDownStartTime;
            Debug.Log("Button up");
            //send the calculated force to the shooting function with forceCalc here
            // var vec = new Vector3(10, 10,10); //x: float, y: float, z: float)
            // rb.AddForce(Vector2.up * 2); // , Impluse);

            Invoke("activateCollision", 1);
            Invoke("CreateBubble", 1);
        }

            









            //Debug.Log("the bubble position is: " + transform.position.y);
            /*  if (!Cheyshoot)
              {
                  bubble.transform.position = rocketLauncher.transform.GetChild(0).position;
                  rb.velocity = Vector2.zero;
              }
             /* else if (Cheyshoot)
              {
                  if (this.CompareTag("Chey"))
                  {
                      rb.velocity = rocketLauncher.transform.right * speed;
                      Invoke("activateCollision", 1);
                  }
              }*/

            /*  if (!Mollushoot)
              {
                  bubble.transform.position = rocketLauncher.transform.GetChild(0).position;
                  rb.velocity = Vector2.zero;
              }
             /* else if (Mollushoot)
              {
                  if (this.CompareTag("Mollu"))
                  {

                  }
              }*/

            /*
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
                    if (Input.GetKeyUp(GameManager.GM.RightPlayershoot))//End charge
                    {
                       // Cheyshoot = true;
                        Mollushoot = true;
                        float holdTime = Time.time - holdDownStartTime;
                        Debug.Log("Button up");
                        //send the calculated force to the shooting function with forceCalc here
                        // var vec = new Vector3(10, 10,10); //x: float, y: float, z: float)
                        // rb.AddForce(Vector2.up * 2); // , Impluse);

                        if (CompareTag("Mollu"))
                        {
                            rb.velocity = rocketLauncher.transform.right * speed;
                            Invoke("activateCollision", 1);
                            Invoke("CreateBubble", 1);

                        }



                    }
                    if (Input.GetKeyUp(GameManager.GM.LeftPlayershoot))//End charge
                    {
                        Cheyshoot = true;
                        Mollushoot = true;
                        float holdTime = Time.time - holdDownStartTime;
                        Debug.Log("Button up");
                        //send the calculated force to the shooting function with forceCalc here
                        // var vec = new Vector3(10, 10,10); //x: float, y: float, z: float)
                        // rb.AddForce(Vector2.up * 2); // , Impluse);

                        if (CompareTag("Chey"))
                        {
                            rb.velocity = rocketLauncher.transform.right * speed;
                            Invoke("activateCollision", 1);
                            Invoke("CreateBubble", 1);

                        }



                    }*/
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
        newBubble = Instantiate(bubble, rocketLauncher.transform.GetChild(0).position, rocketLauncher.transform.GetChild(0).rotation);
        bubble = newBubble;
    }

    public void activateCollision()
    {
        cd.enabled = true;
    }
}


