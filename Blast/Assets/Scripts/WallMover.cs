using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallMover : MonoBehaviour
{

    private bool shouldLerp = false;
    public float timeStartedLerping;
    public float lerpTime;
    [Tooltip("The start coordinates for the upper wall")] [SerializeField] public Vector2 startPositionWall;
    [Tooltip("The end coordinates for the upper wall")] [SerializeField] public Vector2[] endPositionWall;//3 positions
    public static int pos;

    // Update is called once per frame
    void Update()
    {
        
        if (shouldLerp)
        {
            switch (pos)
            {
                case 0://first position
                    transform.position = LerpTest(startPositionWall, endPositionWall[0], timeStartedLerping, lerpTime);
                    break;
                case 1://second position
                    transform.position = LerpTest(startPositionWall, endPositionWall[1], timeStartedLerping, lerpTime);
                    break;
                case 2://third position
                    transform.position = LerpTest(startPositionWall, endPositionWall[2], timeStartedLerping, lerpTime);
                    break;
                case 3://close
                    transform.position = LerpTest(transform.position, startPositionWall, timeStartedLerping, lerpTime);
                    break;
            }
                

            
        }
    }


    public void StartLerping()
    {
        timeStartedLerping = Time.time;
        shouldLerp = true;
    }

    public Vector3 LerpTest(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        return result;
    }

}
