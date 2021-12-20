using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private CharacterController characterController;
    private Vector2 moveInputs;
    private Vector2 mouseInputs;
    public Vector2 sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInputs();
        applyMovement();
        applyMouseRotation();
    }

    private void updateInputs()
    {
        updateMoveInputs();
        updateMouseInputs();
    }

    private void updateMouseInputs()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        mouseInputs = new Vector2(horizontal, vertical);
    }

    private void updateMoveInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveInputs = new Vector2(horizontal, vertical);
    }

    private void applyMovement()
    {
        Vector3 movement = new Vector3(moveInputs.x, 0, moveInputs.y);
        characterController.Move(movement * Time.deltaTime * speed);
    }

    private void applyMouseRotation()
    {
        Vector3 lookRotation = new Vector3(mouseInputs.y, mouseInputs.x, 0);
        lookRotation = (lookRotation * sensitivity) * Time.deltaTime;
        characterController.transform.Rotate(lookRotation);
    }
}
