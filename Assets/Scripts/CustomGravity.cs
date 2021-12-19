using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{

    /*
        Todo
        - Zero out the initialGravityVelocity when on ground
        - Don't apply gravity when on ground
    */

    CharacterController characterController;
    public Vector3 gravityAcceleration = -9.81f;
    public Vector3 gravityVelocity = 0;
    private Vector3 previousGravityVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        previousGravityVelocity = gravityVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        applyGravity();
    }

    private void applyGravity()
    {
        // Need to convert acceleration to distance
        // Formula: d = vt + 1/2at^2

        Vector3 displacement = downwardVelocity * Time.deltaTime + (1 / 2) * (gravityAcceleration) * (Time.deltaTime) ^ 2;

    }
}
