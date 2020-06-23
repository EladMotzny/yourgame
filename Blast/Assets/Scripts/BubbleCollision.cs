﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleCollision : MonoBehaviour
{

    public Rigidbody2D rb;

    //public GameManager GM;
    public Transform blackBall;
    public Transform[] colors;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //transform.position += movement * Time.deltaTime * moveSpeed;
    }
    
    //In order for this to work the bubbles need to have RigidBody2d on them
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if ball hit edge or ball in barrel, destroy what hit
        if (collision.gameObject.CompareTag("edge") && (!this.gameObject.CompareTag("CheyBall") || !this.gameObject.CompareTag("MolluBall")))
        { 
            Destroy(this.gameObject);
        }    
        /*
        //Hit same color ball which has the same tag -DO NOT DESTROY
        else if (collision.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Same color collision detected!");
            Destroy(this.gameObject);
        }*/



        //Mollu or Chey hit a red ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallRedBall") && (this.gameObject.CompareTag("RedBall") || this.gameObject.CompareTag("MolluBallRedBall")) && this.transform.position.x > 0.14 || collision.gameObject.CompareTag("CheyBallRedBall") && (this.gameObject.CompareTag("RedBall") || this.gameObject.CompareTag("CheyBallRedBall")) && this.transform.position.x < 0.14)
        {
            //Debug.Log("Destroy red ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        //Mollu or Chey hit a blue ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallBlueBall") && (this.gameObject.CompareTag("BlueBall") || this.gameObject.CompareTag("MolluBallBlueBall")) && this.transform.position.x > 0.14 || collision.gameObject.CompareTag("CheyBallBlueBall") && (this.gameObject.CompareTag("BlueBall") || this.gameObject.CompareTag("CheyBallBlueBall")) && this.transform.position.x < 0.14)
        {
            //Debug.Log("Destroy blue ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        //Mollu or Chey hit a green ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallGreenBall") && (this.gameObject.CompareTag("GreenBall") || this.gameObject.CompareTag("MolluBallGreenBall")) && this.transform.position.x > 0.14 || collision.gameObject.CompareTag("CheyBallGreenBall") && (this.gameObject.CompareTag("GreenBall") || this.gameObject.CompareTag("CheyBallGreenBall")) && this.transform.position.x < 0.14)
        {
            //Debug.Log("Destroy green ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        //Mollu or Chey hit a yellow ball on their side of the game map
        else if (collision.gameObject.CompareTag("MolluBallYellowBall") && (this.gameObject.CompareTag("YellowBall") || this.gameObject.CompareTag("MolluBallYellowBall")) && this.transform.position.x > 0.14 || collision.gameObject.CompareTag("CheyBallYellowBall") && (this.gameObject.CompareTag("YellowBall") || this.gameObject.CompareTag("CheyBallYellowBall")) && this.transform.position.x < 0.14)
        {
            //Debug.Log("Destroy yellow ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }
        


        //Mollu hits a ball on Cheys side
        else if ((collision.gameObject.CompareTag("MolluBallYellowBall") || collision.gameObject.CompareTag("MolluBallGreenBall") || collision.gameObject.CompareTag("MolluBallBlueBall") || collision.gameObject.CompareTag("MolluBallRedBall")) && this.transform.position.x < 0.14)
        {
            Destroy(collision.gameObject);

           
               // Debug.Log("Freeze Chey!");
           
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
        else
        {
            //Debug.Log("I DIDNT HIT BALL");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        

    }

}
