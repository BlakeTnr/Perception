using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject otherPortal;

    void OnTriggerEnter(Collider other)
    {
        CharacterController player = other.GetComponent<CharacterController>();
        teleport(player);
    }

    private void teleport(CharacterController player)
    {
        setPlayerPosition(player, otherPortal.transform.position);
        Debug.Log(player.transform.position);
    }

    private void setPlayerPosition(CharacterController player, Vector3 position)
    {
        characterControllerFix(player, true);
        player.transform.position = position;
        characterControllerFix(player, false);
    }

    private void characterControllerFix(CharacterController player, bool fixEnabled)
    {
        player.enabled = !fixEnabled;
    }

    private Vector3 getDisplacement(Vector3 a, Vector3 b)
    {
        float x = a.x - b.x;
        float y = a.y - b.y;
        float z = a.z - b.z;

        Vector3 displacement = new Vector3(x, y, z);
        return displacement;
    }
}
