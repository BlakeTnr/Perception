using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        calculateDisplacementDistance();
        moveCharacterIntoGround();
        bool isGrounded = characterController.isGrounded;
        undoMoveCharacterIntoGround();
        return isGrounded;
    }

    private void calculateDisplacementDistance()
    {
        // Divide gravityForce by the absolute value of the largest value in the gravity force to get the displacement distance
        displacementDistance = gravityForce / largestAbsoluteValueInGravityForce();
    }

    private float largestAbsoluteValueInGravityForce()
    {
        float x = Mathf.Abs(gravityForce.x);
        float y = Mathf.Abs(gravityForce.y);
        float z = Mathf.Abs(gravityForce.z);

        float[] xyz = { x, y, z };
        float maxValue = xyz.Max();
        return maxValue;
    }

    private void moveCharacterIntoGround()
    {
        characterController.Move(displacementDistance);
    }

    private void undoMoveCharacterIntoGround()
    {
        Vector3 oppositeDisplacementDistance = displacementDistance * -1;
        characterController.Move(oppositeDisplacementDistance);
    }
}
