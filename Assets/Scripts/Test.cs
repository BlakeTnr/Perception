using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void OnControllerColliderHit(ControllerColliderHit other)
    {
        Debug.Log("test");
        Debug.Log(other.point);
    }
}
