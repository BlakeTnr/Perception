using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck
{

    CharacterController characterController;
    Vector3 gravityForce;
    Vector3 displacementDistance;

    public GroundCheck(CharacterController characterController, Vector3 gravityForce)
    {
        this.characterController = characterController;
        this.gravityForce = gravityForce;
    }

    public bool isGrounded()
    {
        moveCharacterIntoGround();
        bool isGrounded = characterController.isGrounded;
        undoMoveCharacterIntoGround();
        return isGrounded;
    }

    private void calculateDisplacementDistance()
    {
        // Divide gravityForce by the absolute value of the largest value in the gravity force to get the displacement distance
        Vector3 absoluteValuedGravityForce = new Vector3(Mathf.Abs(gravityForce.x), Mathf.Abs(gravityForce.y), Mathf.Abs(gravityForce.z));
        displacementDistance = gravityForce / absoluteValuedGravityForce;
    }

    private void moveCharacterIntoGround()
    {

    }

    private void undoMoveCharacterIntoGround()
    {

    }
}
