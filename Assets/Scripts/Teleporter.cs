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
            Rigidbody player = other.GetComponent<Rigidbody>();
            teleport(player);
        }
    }

    void OnTriggerExit()
    {
        gameObject.GetComponent<Teleporter>().enabled = true;
    }

    private void teleport(Rigidbody player)
    {
        /*
        fixInfiniteTeleporting();
        rotatePlayer(player);
        portalPositionPlayer(player);
        rotateGravity(player.gameObject.GetComponent<RigidBodyCustomGravity>());
        */

        fixInfiniteTeleporting();
        rotatePlayer(player); // Issue is here
        portalPositionPlayer(player);
        //rotateGravity(player.gameObject.GetComponent<RigidBodyCustomGravity>());
    }

    private void fixInfiniteTeleporting()
    {
        otherPortal.GetComponent<Teleporter>().enabled = false;
    }

    private void portalPositionPlayer(Rigidbody player)
    {
        Vector3 relativeToEnterPortal = gameObject.transform.InverseTransformPoint(player.transform.position);
        relativeToEnterPortal = flipVector3XZ(relativeToEnterPortal);
        Vector3 worldPositionExit = otherPortal.transform.TransformPoint(relativeToEnterPortal);
        player.transform.position = worldPositionExit; // Could need fix
    }

    private void rotateGravity(RigidBodyCustomGravity customGravity)
    {
        Vector3 portalRotationDifference = gameObject.transform.rotation.eulerAngles - otherPortal.transform.rotation.eulerAngles;
        Vector3 newGravity = Quaternion.Euler(portalRotationDifference) * customGravity.gravityForce;
        customGravity.gravityForce = newGravity;
    }

    private void rotatePlayer(Rigidbody player)
    {
        Transform cameraTransform = player.transform.Find("Camera");
        rotatePlayerToOtherPortal(player.gameObject, cameraTransform);
        makePlayerLookOut(player);
    }

    private void rotatePlayerToOtherPortal(GameObject player, Transform cameraTransform)
    {
        Quaternion playerLocalRotation = Quaternion.Inverse(gameObject.transform.rotation) * cameraTransform.rotation;
        Quaternion newWorldRotation = otherPortal.transform.rotation * playerLocalRotation;
        player.transform.rotation = newWorldRotation;
    }

    private void makePlayerLookOut(Rigidbody player) // THIS NEEDS TO USE TRANSFORM OF THE CAMERA NOT ROTATION OF PLAYER!!!!!!
    {
        player.transform.Rotate(player.rotation * new Vector3(0, 180, 0)); // Can't use rotate 180
    }

    private Vector3 flipVector3XZ(Vector3 vector)
    {
        return Vector3.Scale(vector, new Vector3(-1, 1, -1));
    }

}
