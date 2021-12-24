using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject otherPortal;

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Teleporter>().enabled)
        {
            CharacterController player = other.GetComponent<CharacterController>();
            teleport(player);
        }
    }

    void OnTriggerExit()
    {
        gameObject.GetComponent<Teleporter>().enabled = true;
    }

    private void teleport(CharacterController player)
    {
        fixInfiniteTeleporting();
        portalPositionPlayer(player);
        makePlayerLookOut(player);
    }

    private void fixInfiniteTeleporting()
    {
        otherPortal.GetComponent<Teleporter>().enabled = false;
    }

    private void portalPositionPlayer(CharacterController player)
    {
        Vector3 relativeToEnterPortal = gameObject.transform.InverseTransformPoint(player.transform.position);
        relativeToEnterPortal = flipVector3XZ(relativeToEnterPortal);
        Vector3 worldPositionExit = otherPortal.transform.TransformPoint(relativeToEnterPortal);
        setPlayerPosition(player, worldPositionExit);
    }

    private void makePlayerLookOut(CharacterController player)
    {
        player.transform.Rotate(new Vector3(0, 180, 0));
    }

    private Vector3 flipVector3XZ(Vector3 vector)
    {
        return Vector3.Scale(vector, new Vector3(-1, 1, -1));
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
