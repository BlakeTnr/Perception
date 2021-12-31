using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 mouseInputs;
    public Vector2 sensitivity;

    void Start() {
        useSavedSensitivity();
    }

    private void useSavedSensitivity() {
        float savedSensitivity = PlayerPrefs.GetFloat("sensitivity", 100);
        sensitivity = new Vector2(savedSensitivity, savedSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        updateMouseInputs();
        applyMouseRotation();
        applyZRotationFix();
    }

    private void updateMouseInputs()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        mouseInputs = new Vector2(horizontal, vertical);
    }

    private void applyMouseRotation()
    {
        Vector2 flippedMouseInputs = new Vector2(mouseInputs.y, mouseInputs.x);
        Vector3 lookRotation = (flippedMouseInputs * sensitivity) * Time.deltaTime;
        Vector3 newLocalRotation = gameObject.transform.localRotation.eulerAngles + lookRotation;
        gameObject.transform.localRotation = Quaternion.Euler(newLocalRotation);
    }

    private void applyZRotationFix() // For loose coupling, this maybe should be it's own script
    {
        Vector3 rotation = gameObject.transform.localRotation.eulerAngles;
        rotation.z = 0;
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
    }
}
