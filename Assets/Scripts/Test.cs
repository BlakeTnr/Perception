using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        this.characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(new Vector3(1, 0, 0) * Time.deltaTime * 3);
    }
}
