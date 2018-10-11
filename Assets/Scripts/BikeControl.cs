using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour {

    private Rigidbody rBody;
    private Vector3 inputVector; //pass keyboard data from update to fixed update

    public float moveSpeed = 10f;
    public float turnSpeed = 90f;
    public float lookSpeed = 300f;
	
    // Use this for initialization
    void Start ()
    {
        //cache reference to Rigidbody
        rBody = GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
    void Update ()
    {
        //mouse look
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;	//mouseX = horizontal mouseDelta
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;	//mouseY = vertical mouseDelta
        
        //rotate y axis for movement/look
        //transform.Rotate(0f, mouseX, 0f);
        Camera.main.transform.Rotate(0f, mouseX, 0f);
        //Camera.main.transform.Rotate(-mouseY,0f,0f);
        Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f); //camera rotation
        Camera.main.transform.localEulerAngles -= new Vector3(0, 0, Camera.main.transform.localEulerAngles.z);
       
        
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
        if (inputVector.y > 0)
        {
            rBody.AddForce(transform.forward * moveSpeed);
        }
      
        if (inputVector.y < 0)
        {
            rBody.AddForce(-rBody.velocity);
        }
        //left and right turning with rotational force or Torque, 0 for x
        rBody.AddTorque(0f, inputVector.x * turnSpeed, 0f);
    }
}
