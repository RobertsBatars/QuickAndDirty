using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public bool player1;
    [Space]
    public float acceleration = 500f;
    public float breakForce = 300f;
    public float maxTurnAngle = 15f;
    [Space]
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] WheelCollider backRight;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentBreakForce = 0;

        if (player1)
        {
            currentAcceleration = acceleration * Input.GetAxis("Vertical");
            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakForce;
            }
        }
        else
        {
            currentAcceleration = 0;
            currentTurnAngle = 0;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                currentAcceleration -= acceleration;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                currentAcceleration += acceleration;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                currentTurnAngle -= maxTurnAngle;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                currentTurnAngle += maxTurnAngle;
            }
            if (Input.GetKey(KeyCode.Keypad0))
            {
                currentBreakForce = breakForce;
            }
        }
    }

    private void FixedUpdate()
    {
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
    }
}
