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
    private Vector3 rocketTemp;
    //[Tooltip("Time to get to max force")] [SerializeField] float maxForceTime = 2f;
    //[Tooltip("Maximum force to launch the missle at")] [SerializeField] float maxForce = 500f;
    bool shoot;
    public float speed = 7f;
    Transform bubble;
    private string Temptag;
    public CircleCollider2D cd;
    public Transform[] colors;

    public GameObject LeftInfoPanel;
    Transform nextBubble;
    int rand;

    void Start()
    {
        shoot = false;

        nextBubble = createNextLeftBubble();

        CreateBubble(UnityEngine.Random.Range(0, 4));

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
            if (rb != null)
            {
                
                rb.velocity = rocketTemp * speed;
                Invoke("activateCollision", 1);
            }
            else
            {
                Destroy(rb);
            }

        }
        if (Input.GetKeyDown(GameManager.GM.LeftPlayershoot))//Start charging
        {
            //Debug.Log("Button down");
            holdDownStartTime = Time.time;
        }
        /*if (Input.GetKey(GameManager.GM.LeftPlayershoot))//Mid charge
        {
            //Debug.Log("charging...");
            float currHoldTime = Time.time - holdDownStartTime;

            //ShowForce(forceCalc(currHoldTime));
        }*/
        if (Input.GetKey(GameManager.GM.LeftPlayershoot) && !shoot)//End charge
        {
            shoot = true;
            //float holdTime = Time.time - holdDownStartTime;
            //Debug.Log("Button up");
            //send the calculated force to the shooting function with forceCalc here
            // var vec = new Vector3(10, 10,10); //x: float, y: float, z: float)
            // rb.AddForce(Vector2.up * 2); // , Impluse);
            rocketTemp = rocketLauncher.transform.right;
            //speed = forceCalc(holdTime);
            bubble.tag = "CheyBall" + Temptag;
            Invoke("activateCollision", 1);
            Invoke("nextBubbleAssign", 1);
        }

    }

    /*
    private float forceCalc(float holdTime)
    {
        if (holdTime >= maxForceTime)
        {
            holdTime = maxForceTime;
        }
        float force = holdTime / maxForceTime * maxForce;
        return force;

    }

    private void HideForce()
    {
        forceSpriteMask.alphaCutoff = 1;
    }

    public void ShowForce(float force)
    {
        forceSpriteMask.alphaCutoff = 1 - force / maxForce;
    }*/

    public void CreateBubble(int next)
    {
        shoot = false;
    
        bubble = Instantiate(colors[next], rocketLauncher.transform.GetChild(0).position, rocketLauncher.transform.GetChild(0).rotation);
        Temptag = bubble.tag;
        rb = bubble.GetComponent<Rigidbody2D>();

        cd = bubble.GetComponent<CircleCollider2D>();
        cd.enabled = false;

        bubble.tag = "CheyBall";

        bubble.position = rocketLauncher.transform.GetChild(0).position;

    }

    public void activateCollision()
    {
        if (cd != null)
        {
            cd.enabled = true;
        }
        if (cd == null)
        {
            Destroy(cd);
        }
    }


    public Transform createNextLeftBubble()
    {
        rand = UnityEngine.Random.Range(0, 4);
        Transform newBubble = Instantiate(colors[rand], LeftInfoPanel.transform.GetChild(1).position, LeftInfoPanel.transform.GetChild(1).rotation);


        Rigidbody2D rb = newBubble.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        CircleCollider2D cd = newBubble.GetComponent<CircleCollider2D>();
        cd.enabled = false;

        newBubble.tag = "newBall";

        newBubble.position = LeftInfoPanel.transform.GetChild(1).position;
        newBubble.transform.SetAsLastSibling();

        return newBubble;


    }

    //assign the next ball to the rocket ball and change it
    public void nextBubbleAssign()
    {
        CreateBubble(rand);
        Destroy(nextBubble.gameObject);
        nextBubble = createNextLeftBubble();

    }
}


