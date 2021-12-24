using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(player.transform.position);
        Debug.Log("c");
    }
}
