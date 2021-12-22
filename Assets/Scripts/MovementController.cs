using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed;
    private CharacterController characterController;
    private Vector2 moveInputs;
    public Transform rotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMoveInputs();
        applyMovementInLookDirection();
    }

    private void updateMoveInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveInputs = new Vector2(horizontal, vertical);
    }

    private void applyMovementInLookDirection()
    {
        Vector3 inputMovement = new Vector3(moveInputs.x, 0, moveInputs.y);
        Vector3 movement = inputMovement * Time.deltaTime * speed;
        Vector3 movementInLookDirection = rotation.TransformDirection(movement);
        characterController.Move(movementInLookDirection);
    }
}
