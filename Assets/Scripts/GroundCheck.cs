using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundCheck : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded;
    public Collider characterControllerCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != characterControllerCollider) // Is being triggered by CharacterController
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject != characterControllerCollider)
        {
            isGrounded = false;
        }
    }
}
