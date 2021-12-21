using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Worked!");
    }

    void OnColliderEnter(Collision other)
    {
        Debug.Log("Collision");
    }
}
