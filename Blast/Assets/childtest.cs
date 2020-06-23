using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childtest : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform level;
    int i = 0;
    void Start()
    {
        Debug.Log(level.childCount);
        count();
    }

    private void Update()
    {
        Debug.Log(level.childCount);
    }

    void count()
    {
        foreach (Transform child in level.transform)
        {
            i++;
            Debug.Log(i);
        }
    }
}
