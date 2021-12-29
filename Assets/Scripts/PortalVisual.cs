using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalVisual : MonoBehaviour
{

    public GameObject otherPortalView;
    public GameObject playerCamera;
    public Shader screenCutoutShader;
    private GameObject otherPortal;
    private GameObject gameObjectPortal;
    private GameObject portalCamera;
    private RenderTexture renderTexture;

    // Start is called before the first frame update
    void Start()
    {
        otherPortal = getParentPortal(otherPortalView);
        gameObjectPortal = getParentPortal(gameObject);
        createPortalCamera();
        gameObject.GetComponent<Renderer>().material.mainTexture = renderTexture;
        gameObject.GetComponent<Renderer>().material.shader = screenCutoutShader;
    }

    private void createPortalCamera()
    {
        // Copy projection settings over
        instantiateCameraObject();
    }

    private void transformOtherCamera()
    {
        Transform portalCameraPreviousParentTransform = portalCamera.transform.parent;
        Transform playerCameraPreviousParentTransform = playerCamera.transform.parent;
        portalCamera.transform.parent = otherPortalView.transform;
        playerCamera.transform.parent = gameObjectPortal.transform;
        positionCamera();
        rotateCamera();
        portalCamera.transform.parent = portalCameraPreviousParentTransform;
        playerCamera.transform.parent = playerCameraPreviousParentTransform;
    }

    private void positionCamera()
    {
        Vector3 newPosition = Vector3.Scale(playerCamera.transform.localPosition, new Vector3(-1, 1, -1));
        portalCamera.transform.localPosition = newPosition;
    }

    private void rotateCamera()
    {
        rotateOtherCamera180();
    }

    private void rotateOtherCamera180()
    {
        Vector3 newRotation = playerCamera.transform.localRotation.eulerAngles + new Vector3(0, 180, 0);
        portalCamera.transform.localRotation = Quaternion.Euler(newRotation);
    }

    private void instantiateCameraObject()
    {
        portalCamera = new GameObject();
        portalCamera.AddComponent<Camera>();
        createRenderTexture();
        portalCameraSettings();
    }

    private void portalCameraSettings()
    {
        copyPlayerProjectionMatrix();
        setRenderTexture();
        setCullingMask();
    }

    private void setCullingMask()
    {
        int ignoreLayer3 = ((1 << 0) | (1 << 1) | (1 << 2) | (1 << 4) | (1 << 5)); // This system is shitty and shouldn't be automatic
        portalCamera.GetComponent<Camera>().cullingMask = ignoreLayer3;
    }

    private void setRenderTexture()
    {
        portalCamera.GetComponent<Camera>().targetTexture = renderTexture;
    }

    private void createRenderTexture()
    {
        renderTexture = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
    }

    private void copyPlayerProjectionMatrix()
    {
        portalCamera.GetComponent<Camera>().projectionMatrix = playerCamera.GetComponent<Camera>().projectionMatrix;
    }

    private GameObject getParentPortal(GameObject portalView)
    {
        return portalView.transform.parent.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transformOtherCamera();
    }

}
