using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleCollision : MonoBehaviour
{

    public Rigidbody2D rb;

    
    public Transform blackBall;
    public Transform[] colors;
    public AudioSource iceSound;
    void Start()
    {
        iceSound = GameManager.GM.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    //In order for this to work the bubbles need to have RigidBody2d on them
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if ball hit edge or ball in barrel, destroy what hit
        if (collision.gameObject.CompareTag("edge") && (!this.gameObject.CompareTag("CheyBall") || !this.gameObject.CompareTag("MolluBall")))
        { 
            Destroy(this.gameObject);
        }    

        
        //Hit same color ball which has the same tag 
        else if (collision.gameObject.CompareTag(gameObject.tag))
        {
            if (this.transform.position.x < -0.14)
            {
                GameManager.GM.updateNumberOfBubblesLeft();
            }
            else
            {
                GameManager.GM.updateNumberOfBubblesRight();
            }
            Debug.Log("Same color collision detected!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            

        }



        //Mollu or Chey hit a red ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallRedBall") && this.gameObject.CompareTag("RedBall") && this.transform.position.x > 0.14)
        {
            Debug.Log("Destroy red ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesRight();
        }

        else if (collision.gameObject.CompareTag("CheyBallRedBall") && (this.gameObject.CompareTag("RedBall") || this.gameObject.CompareTag("CheyBallRedBall")) && this.transform.position.x < -0.14)
        {
            Debug.Log("Destroy red ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesLeft();
        }

        //Mollu or Chey hit a blue ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallBlueBall") && (this.gameObject.CompareTag("BlueBall") || this.gameObject.CompareTag("MolluBallBlueBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("Destroy blue ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesRight();
        }

        else if (collision.gameObject.CompareTag("CheyBallBlueBall") && (this.gameObject.CompareTag("BlueBall") || this.gameObject.CompareTag("CheyBallBlueBall")) && this.transform.position.x < -0.14)
        {
            Debug.Log("Destroy blue ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesLeft();
        }
        //Mollu or Chey hit a green ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallGreenBall") && (this.gameObject.CompareTag("GreenBall") || this.gameObject.CompareTag("MolluBallGreenBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("Destroy green ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesRight();
        }

        else if ( collision.gameObject.CompareTag("CheyBallGreenBall") && (this.gameObject.CompareTag("GreenBall") || this.gameObject.CompareTag("CheyBallGreenBall")) && this.transform.position.x < -0.14)
        {
            Debug.Log("Destroy green ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesLeft();
        }

        //Mollu or Chey hit a yellow ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallYellowBall") && (this.gameObject.CompareTag("YellowBall") || this.gameObject.CompareTag("MolluBallYellowBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("Destroy yellow ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesRight();
        }

        else if (collision.gameObject.CompareTag("CheyBallYellowBall") && (this.gameObject.CompareTag("YellowBall") || this.gameObject.CompareTag("CheyBallYellowBall")) && this.transform.position.x < 0.14)
        {
            Debug.Log("Destroy yellow ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.GM.updateNumberOfBubblesLeft();
        }



        //Mollu hits a ball on Cheys side
        else if ((collision.gameObject.CompareTag("MolluBallYellowBall") || collision.gameObject.CompareTag("MolluBallGreenBall") || collision.gameObject.CompareTag("MolluBallBlueBall") || collision.gameObject.CompareTag("MolluBallRedBall")) && this.transform.position.x < 0.14)
        {
            Destroy(collision.gameObject);


            // Debug.Log("Freeze Chey!");
            iceSound.Play();
                Debug.Log("Freeze Cheys ball!");
                Instantiate(blackBall, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
           // }
            // GM.updateNumberOfBubblesLeft();
        }

        //Chey hits a ball on Mollus side
        else if ((collision.gameObject.CompareTag("CheyBallYellowBall") || collision.gameObject.CompareTag("CheyBallGreenBall") || collision.gameObject.CompareTag("CheyBallBlueBall") || collision.gameObject.CompareTag("CheyBallRedBall")) && this.transform.position.x > 0.14)
        {
            Destroy(collision.gameObject);


            // Debug.Log("Freeze Mollu!");
            iceSound.Play();
            Debug.Log("Freeze Mollus ball!");
                Instantiate(blackBall, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            
            // GM.updateNumberOfBubblesLeft();
        }

        //Chey hits the black ball to unfreeze it - and changes it to the hitting ball color
        else if ((collision.gameObject.CompareTag("CheyBallYellowBall") || collision.gameObject.CompareTag("CheyBallGreenBall") || collision.gameObject.CompareTag("CheyBallBlueBall") || collision.gameObject.CompareTag("CheyBallRedBall")) && this.transform.position.x < 0.14 && this.CompareTag("BlackBall"))
        {
            //Debug.Log("Unfreeze Cheys ball!");
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("CheyBallRedBall"))
            {
                Instantiate(colors[0], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("CheyBallGreenBall"))
            {
                Instantiate(colors[2], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("CheyBallBlueBall"))
            {
                Instantiate(colors[1], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("CheyBallYellowBall"))
            {
                Instantiate(colors[3], this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }


        //Mollu hits the black ball to unfreeze it - and changes it to the hitting ball color
        else if ((collision.gameObject.CompareTag("MolluBallYellowBall") || collision.gameObject.CompareTag("MolluBallGreenBall") || collision.gameObject.CompareTag("MolluBallBlueBall") || collision.gameObject.CompareTag("MolluBallRedBall")) && this.transform.position.x > 0.14 && this.CompareTag("BlackBall"))
        {
            //Debug.Log("Unfreeze Mollus ball!");
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("MolluBallRedBall"))
            {
                Instantiate(colors[0], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("MolluBallGreenBall"))
            {
                Instantiate(colors[2], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("MolluBallBlueBall"))
            {
                Instantiate(colors[1], this.transform.position, this.transform.rotation);
            }
            if (collision.gameObject.CompareTag("MolluBallYellowBall"))
            {
                Instantiate(colors[3], this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        else if (collision.gameObject.CompareTag("MolluBall"))
        {
            //Mollu lost, change scene to cheywin
            SceneManager.LoadScene("CheyWon");
        }
        else if (collision.gameObject.CompareTag("CheyBall"))
        {
            //Chey lost, change scene to Molluwin
            SceneManager.LoadScene("MolluWon");
            
        }

        //hit a bubble not in the same color, freeze in place unless its in the chamber

       /* else if(collision.gameObject.CompareTag("MolluBallRedBall") && (this.CompareTag ("GreenBall") || this.CompareTag("YellowBall") || this.CompareTag("BlueBall") || this.CompareTag("MolluBallGreenBall") || this.CompareTag("MolluBallYellowBall") || this.CompareTag("MolluBallBlueBall")))
        {
            Debug.Log("I HIT NOT RED BALL");

            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameManager.GM.increaseNumberOfBubblesRight();
        }*/

        else if (this.CompareTag("MolluBallRedBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("I HIT NOT RED BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "RedBall";
            GameManager.GM.increaseNumberOfBubblesRight();
        }

        else if (this.CompareTag("MolluBallBlueBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("I HIT NOT BLUE BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "BlueBall";
            GameManager.GM.increaseNumberOfBubblesRight();
        }

        else if (this.CompareTag("MolluBallGreenBall") && (collision.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("I HIT NOT GREEN BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "GreenBall";
            GameManager.GM.increaseNumberOfBubblesRight();
        }

        else if (this.CompareTag("MolluBallYellowBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x > 0.14)
        {
            Debug.Log("I HIT NOT YELLOW BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "YellowBall";
            GameManager.GM.increaseNumberOfBubblesRight();
        }




        else if (this.CompareTag("CheyBallRedBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x < 0.14)
        {
            Debug.Log("I HIT NOT RED BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "RedBall";
            GameManager.GM.increaseNumberOfBubblesLeft();
        }

        else if (this.CompareTag("CheyBallBlueBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("RedBall")) && this.transform.position.x < 0.14)
        {
            Debug.Log("I HIT NOT BLUE BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "BlueBall";
            GameManager.GM.increaseNumberOfBubblesLeft();
        }

        else if (this.CompareTag("CheyBallGreenBall") && (collision.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x < 0.14)
        {
            Debug.Log("I HIT NOT GREEN BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "GreenBall";
            GameManager.GM.increaseNumberOfBubblesLeft();
        }

        else if (this.CompareTag("CheyBallYellowBall") && (collision.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("BlueBall")) && this.transform.position.x < 0.14)
        {
            Debug.Log("I HIT NOT YELLOW BALL");

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.tag = "YellowBall";
            GameManager.GM.increaseNumberOfBubblesLeft();
        }


    }

}
