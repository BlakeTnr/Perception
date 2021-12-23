using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject otherPortal;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.transform.position);
        other.gameObject.transform.position = otherPortal.transform.position;
        Debug.Log(other.gameObject.transform.position);
    }
}
