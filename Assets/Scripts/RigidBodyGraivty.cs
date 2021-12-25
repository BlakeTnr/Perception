using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyGraivty : MonoBehaviour
{

    public Rigidbody rigidbody;
    public Vector3 gravityForce = new Vector3(0, -9.81f, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(gravityForce, ForceMode.Acceleration);
    }
}
