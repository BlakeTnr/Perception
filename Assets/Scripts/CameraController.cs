using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 mouseInputs;
    public Vector2 sensativity;

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
        Vector3 lookRotation = (flippedMouseInputs * sensativity) * Time.deltaTime;
        gameObject.transform.Rotate(lookRotation);
    }

    private void applyZRotationFix() // For loose coupling, this maybe should be it's own script
    {
        Vector3 rotation = gameObject.transform.rotation.eulerAngles;
        rotation.z = 0;
        gameObject.transform.rotation = Quaternion.Euler(rotation);
    }
}
