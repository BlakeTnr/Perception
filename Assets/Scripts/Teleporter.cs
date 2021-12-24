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
        Vector3 relativeToEnterPortal = gameObject.transform.InverseTransformPoint(player.transform.position);
        relativeToEnterPortal = Vector3.Scale(relativeToEnterPortal, new Vector3(1, 1, 1));
        Vector3 worldPositionExit = otherPortal.transform.TransformPoint(relativeToEnterPortal);
        setPlayerPosition(player, worldPositionExit);
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

}
