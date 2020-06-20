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
        if(collision.gameObject.CompareTag(gameObject.tag)|| collision.gameObject.CompareTag("Chey") || collision.gameObject.CompareTag("Mollu"))
        {
            Debug.Log("Same color collision detected!");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GM.updateNumberOfBubblesLeft();
        }

    }
}
