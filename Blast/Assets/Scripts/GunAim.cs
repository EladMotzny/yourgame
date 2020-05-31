using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    [Tooltip("Rotation speed")] [SerializeField]  float rotateSpeed = 50f;
    private float holdDownStartTime;//Time where you start holding the button down
    [Tooltip("Time to get to max force")] [SerializeField] float maxForceTime = 2f;
    [Tooltip("Maximum force to launch the missle at")] [SerializeField] float maxForce = 500f;
    [SerializeField] private Transform forceTransform;
    private SpriteMask forceSpriteMask;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        forceSpriteMask = forceTransform.Find("mask").GetComponent<SpriteMask>();
        HideForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))//rotate left
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))//rotate right
        {
            transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown("space"))//Start charging
        {
            Debug.Log("Button down");
            holdDownStartTime = Time.time;
        }
        if (Input.GetKey("space"))//Mid charge
        {
            Debug.Log("charging...");
            float currHoldTime = Time.time - holdDownStartTime;
            ShowForce(forceCalc(currHoldTime));
        }
        if (Input.GetKeyUp("space"))//End charge
        {
            float holdTime = Time.time - holdDownStartTime;
            Debug.Log("Button up");
            //send the calculated force to the shooting function with forceCalc here
        }
      
    }
  
    private float forceCalc(float holdTime)
    {
        float force = Mathf.Clamp01(holdTime / maxForceTime) * maxForce;
        return force;

    }

    private void HideForce()
    {
        forceSpriteMask.alphaCutoff = 1;
    }

    public void ShowForce(float force)
    {
        forceSpriteMask.alphaCutoff = 1 - force / maxForce;
    }
}
