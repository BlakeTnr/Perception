using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject otherPortalView;
    private GameObject otherPortal;
    private GameObject gameObjectPortal;

    void Start()
    {
        otherPortal = getPortalFromPortalView(otherPortalView);
        gameObjectPortal = getPortalFromPortalView(gameObject);
    }

    private GameObject getPortalFromPortalView(GameObject portalView)
    {
        GameObject portalOutline = portalView.transform.parent.gameObject;
        GameObject portal = portalOutline.transform.parent.gameObject;
        return portal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Teleporter>().enabled)
        {
            teleport(other.gameObject);
        }
    }

    void OnTriggerExit()
    {
        gameObject.GetComponent<Teleporter>().enabled = true;
    }

    private void disableOtherPortal()
    {
        otherPortalView.GetComponent<Teleporter>().enabled = false;
    }

    private void teleport(GameObject player)
    {
        disableOtherPortal();
        portalPositionplayer(player);
        portalRotatePlayer(player);
        rotateGravity(player.GetComponent<RigidBodyCustomGravity>());
    }

    private void portalPositionplayer(GameObject player)
    {
        movePlayerLocally(player);
        // should do some flipping sign of x or z (I forgot) to make seamless
    }

    private void movePlayerLocally(GameObject player)
    {
        Transform previousParent = player.transform.parent;
        player.transform.parent = gameObjectPortal.transform;

        Vector3 localPosition = player.transform.localPosition;
        player.transform.parent = otherPortal.transform;
        player.transform.localPosition = localPosition;

        player.transform.parent = previousParent;
    }

    private void portalRotatePlayer(GameObject player)
    {
        GameObject camera = player.transform.Find("Camera").gameObject;
        rotatePlayerLocally(player, camera);
        rotateCameraOutwards(camera.transform);
    }

    private void rotatePlayerLocally(GameObject player, GameObject camera)
    {
        Transform previousParent = player.transform.parent;
        player.transform.parent = gameObjectPortal.transform;

        Quaternion localRotation = player.transform.localRotation;
        player.transform.parent = otherPortal.transform;
        player.transform.localRotation = localRotation;

        player.transform.parent = previousParent;
    }

    private void rotateCameraOutwards(Transform camera)
    {
        Vector3 newRotation = camera.localRotation.eulerAngles + new Vector3(0, 180, 0);
        camera.localRotation = Quaternion.Euler(newRotation);
    }

    private void rotateGravity(RigidBodyCustomGravity rigidBodyCustomGravity)
    {
        Vector3 gravityLocal = gameObjectPortal.transform.InverseTransformVector(rigidBodyCustomGravity.gravityForce);
        Vector3 newGravity = otherPortal.transform.TransformVector(gravityLocal);
        rigidBodyCustomGravity.gravityForce = newGravity;
    }

}
