using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHelper : MonoBehaviour
{
    //add transform for the two walls
    [Tooltip("Change to increase/decrease movement speed")] [SerializeField] float moveSpeed = 1f;
    [Tooltip("Maximum delay for walls to open")] [SerializeField] int openMax = 10;
    [Tooltip("Minimum delay for walls to open")] [SerializeField] int openMin = 3;
    [Tooltip("Maximum delay for walls to close")] [SerializeField] int closeMax = 10;
    [Tooltip("Maximum delay for walls to close")] [SerializeField] int closeMin = 3;
    private System.Random rnd = new System.Random();


    private bool shouldLerp = false;
    public float timeStartedLerping;
    public float lerpTime;
    [Tooltip("The start coordinates for the upper wall")] [SerializeField] public Vector2 startPositionUpWall;
    [Tooltip("The end coordinates for the upper wall")] [SerializeField] public Vector2[] endPositionUpWall;//3 positions
    [Tooltip("The start coordinates for the down wall")] [SerializeField] public Vector2 startPositionDownWall;
    [Tooltip("The end coordinates for the down wall")] [SerializeField] public Vector2[] endPositionDownWall;//3 positions
    public WallMover uppperWall;
    public WallMover downWall;
    //public Transform downWall;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(openWall());
        
    }

    void Update()
    {
        
    }

    public IEnumerator openWall()//function to open the wall after a certain amount of time
    {
        float sec = (float)rnd.Next(openMin, openMax);
        //call function to open wall here
        int position = rnd.Next(0, 2);
        WallMover.pos = position;
        uppperWall.StartLerping();
        downWall.StartLerping();
        Debug.Log("OPEN Wait for " + sec + " seconds");
        yield return new WaitForSeconds(sec);
        StartCoroutine(closeWall());
    }

    public IEnumerator closeWall()
    {
        float sec = (float)rnd.Next(closeMin, closeMax);
        //call function to close wall here
        WallMover.pos = 3;
        uppperWall.StartLerping();
        downWall.StartLerping();
        Debug.Log("CLOSE Wait for " + sec + " seconds");
        yield return new WaitForSeconds(sec);
        StartCoroutine(openWall());
    }

}
