using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private CharacterController characterController;
    private Vector2 inputs;

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
    }

    private void updateInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputs = new Vector2(horizontal, vertical);
    }

    private void applyMovement()
    {
        Vector3 movement = new Vector3(inputs.x, 0, inputs.y);
        characterController.Move(movement * Time.deltaTime * speed);
    }
}
