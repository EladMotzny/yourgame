using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBoard : MonoBehaviour
{

    public GameObject[] bubblesPrefabs;
    public List<List<GameObject>> grid; //dont forget to do grid = new List<List<GameObjects>> ();
    public int COLUMN = 9;
    public int ROW = 5;

    // Start is called before the first frame update
    void Start()
    {
        //call function to make the basic grid
    }

    // Update is called once per frame
    void Update()
    {
        //yield 10 seconds
        //AddLine
    }

    //function to make the grid and put in the scene
    public void BuildGrid()
    {
        
    }

    //function to add a new line of bubbles
    public void AddLine()
    {
        //make a list to insert the bubbles
        List<GameObject> bubbleRow = new List<GameObject>();
        //Adding bubbles to the row
        for (int i = 0; i < COLUMN; i++) {
            bubbleRow.Add(bubblesPrefabs[bubbleRandom()]);
        }
        grid.Insert(0, bubbleRow);//Add at the beginning of the grid
    }


    //function to get a ball type (random)
    public int bubbleRandom()
    {
        System.Random rnd = new System.Random();
        int number = rnd.Next(0, 4);
        return number;
    }

    //function that adds a bubble when hit with a bubble from a player
    public void addBubblePlayer(GameObject bubble)
    {
        //get place that got hit
        //add to the grid if its in the range
    }

}
