using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundCheck : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded;
    public float groundIfContactBelowLocalY;

    void Update()
    {
        resetIsGrounded();
    }

    private void resetIsGrounded()
    {
        isGrounded = false;
    }

    void OnControllerColliderHit(ControllerColliderHit controllerHit)
    {
        Vector3 localPoint = gameObject.transform.InverseTransformPoint(controllerHit.point);
        if (localPoint.y <= groundIfContactBelowLocalY)
        {
            isGrounded = true;
            return;
        }
    }
}
