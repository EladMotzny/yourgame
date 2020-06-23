using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheyShoot : MonoBehaviour
{
    public Rigidbody2D rb;
 
    [Tooltip("Launcher")] [SerializeField] GameObject rocketLauncher;

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


        nextBubbleAssign();

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
                
                rb.velocity = rocketLauncher.transform.right * speed;
                Invoke("activateCollision", 1);
            }
            else
            {
                Destroy(rb);
            }

        }
      
        if (Input.GetKey(GameManager.GM.LeftPlayershoot) && !shoot)//End charge
        {
            shoot = true;
           
            bubble.tag = "CheyBall" + Temptag;
            Invoke("activateCollision", 1);
            Invoke("nextBubbleAssign", 1);
        }

    }

    

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


