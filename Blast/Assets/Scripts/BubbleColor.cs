using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BallColor
{
	red,
	green,
	blue,
	yellow
}
public class BubbleColor : MonoBehaviour
{


	public static BallColor GetRandomBallColor()
	{
		int rInt = Random.Range(0, 3);
		return (BallColor)rInt;
	}

}
