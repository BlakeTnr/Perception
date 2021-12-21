using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed;
    private CharacterController characterController;
    private Vector2 moveInputs;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMoveInputs();
        applyMovement();
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
}
