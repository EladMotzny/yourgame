using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{

    //public float moveSpeed = 0f;
    // Start is called before the first frame update
    public GameManager GM;
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

        if (collision.gameObject.CompareTag("edge"))
        { 
            Destroy(this.gameObject);
        }


        else if (collision.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Same color collision detected!");
        }

        else if (collision.gameObject.CompareTag("MolluBallRedBall") && this.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("CheyBallRedBall") && this.gameObject.CompareTag("RedBall"))
        {
            Debug.Log("Destroy red ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        else if (collision.gameObject.CompareTag("MolluBallBlueBall") && this.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("CheyBallBlueBall") && this.gameObject.CompareTag("BlueBall"))
        {
            Debug.Log("Destroy blue ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        else if (collision.gameObject.CompareTag("MolluBallGreenBall") && this.gameObject.CompareTag("GreenBall") || collision.gameObject.CompareTag("CheyBallGreenBall") && this.gameObject.CompareTag("GreenBall"))
        {
            Debug.Log("Destroy green ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

        else if (collision.gameObject.CompareTag("MolluBallYellowBall") && this.gameObject.CompareTag("YellowBall") || collision.gameObject.CompareTag("CheyBallYellowBall") && this.gameObject.CompareTag("YellowBall"))
        {
            Debug.Log("Destroy yellow ball!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // GM.updateNumberOfBubblesLeft();
        }

    }
}
