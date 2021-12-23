using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        player.transform.position = new Vector3(0, 0, 0);
    }
}
