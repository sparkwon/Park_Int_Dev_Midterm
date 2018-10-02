using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour {

    private Rigidbody rBody;
    private Vector3 inputVector;

    public float moveSpeed = 10f;
    public float turnSpeed = 90f;
	
    // Use this for initialization
    void Start ()
    {
        //cache reference to Rigidbody
        rBody = GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
    void Update ()
    {
        //Input.GetAxis returns a number between -1f and 1f.... 0f is nothing is pressed
        //horizontal = A/D, Left -1/Right 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //put input into a vector for physics forces later in FixedUpdate
        inputVector = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        //forward and backward thrust, input.Vector.y cause that's where vertical is held for fixedupdate
        rBody.AddForce(transform.forward * inputVector.y * moveSpeed);
        //left and right turning with rotational force or Torque, 0 for x
        rBody.AddTorque(0f, inputVector.x * turnSpeed, 0f);
    }
}
