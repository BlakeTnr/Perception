using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{

    /*
        How the script works
        - Take previous velocity and store it as a vector
	    - Apply the acceleration to the previousVelocity
        - Store newly applied velocity as previous velocity
    */

    CharacterController characterController;
    public Vector3 gravityAcceleration = new Vector3(0, -9.81f, 0);
    public Vector3 gravityVelocity = new Vector3(0, 0, 0);
    public Vector3 initialGravityVelocity = new Vector3(0, 0, 0);
    private Vector3 previousGravityVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        previousGravityVelocity = initialGravityVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        updateGravityVelocity();
        applyGravityVelocity();
        zeroIfOnGround();
        previousGravityVelocity = gravityVelocity;
    }

    private void applyGravity()
    {
        updateGravityVelocity();
        applyGravityVelocity();
        previousGravityVelocity = gravityVelocity;
    }

    private void zeroIfOnGround()
    {
        if (characterController.isGrounded)
        {
            gravityVelocity = Vector3.zero;
            previousGravityVelocity = Vector3.zero;
        }
    }

    private void applyGravityVelocity()
    {
        Vector3 displacement = gravityVelocity * Time.deltaTime;
        characterController.Move(displacement);
    }

    private void updateGravityVelocity()
    {
        gravityVelocity = previousGravityVelocity + (gravityAcceleration * Time.deltaTime);
    }
}
