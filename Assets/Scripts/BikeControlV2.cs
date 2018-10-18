using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BikeControlV2 : MonoBehaviour
{
	public WheelCollider FLwheel;
	public WheelCollider FRwheel;
	public WheelCollider BLwheel;
	public WheelCollider BRwheel;
	public float lookSpeed = 300f;
	public float maxTorque = 50f;
	public Rigidbody rb;

	private float upDownRotation;
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Vector3 temp = rb.centerOfMass;
		temp.y = -0.9f;
		rb.centerOfMass = temp;
		
	}

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta
		
		// BETTER MOUSE LOOK add mouseinput to upDownRotation AND clamp upDownRotation
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); //clamp vertical look rotation between -80/80
		
		//Apply rotation
		//Camera.main.transform.Rotate(0f, mouseX, 0f);
		Camera.main.transform.localEulerAngles = new Vector3(upDownRotation, 0f, 0f);
		
		//BETTER MOUSE LOOK: LOCK AND HIDE THE MOUSE CURSOR
		//important: do this when the player clicks
		if (Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked;	//lock cursor to center of the screen
			Cursor.visible = false; //hides the cursor too just to be safe
		}
	}
	
	
	void FixedUpdate ()
	{
		BLwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		BRwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FLwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FRwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FLwheel.steerAngle = 60 * Input.GetAxis("Horizontal");
		FRwheel.steerAngle = 60 * Input.GetAxis("Horizontal");

	}
	
	//collision to trigger game over state
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "car")
		{
			FindObjectOfType<GameManager>().EndGame();

		}
			
			
	}
}
