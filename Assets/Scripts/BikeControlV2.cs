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
	private float leftRightRotation;

	private float rightBodyNumber;
	private float leftBodyNumber;
	
	//instructions screen
	public GameObject instructions;
	
	
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

		leftRightRotation += mouseX;
		leftRightRotation = Mathf.Clamp(leftRightRotation, -80f, 80f);
		
		//Apply rotation
		//Camera.main.transform.Rotate(0f, mouseX, 0f);
		Camera.main.transform.localEulerAngles = new Vector3(upDownRotation, leftRightRotation, 0f);
		
		
		//BETTER MOUSE LOOK: LOCK AND HIDE THE MOUSE CURSOR
		//important: do this when the player clicks
		if (Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked;	//lock cursor to center of the screen
			Cursor.visible = false; //hides the cursor too just to be safe
		}
		
		
		//body tilt code
		if (Input.GetKey(KeyCode.D))
		{
			//rightBodyNumber = 0;
			rightBodyNumber += 1;
			rightBodyNumber= Mathf.Clamp(rightBodyNumber, 0, 10);
			
			gameObject.transform.GetChild(2).localEulerAngles = new Vector3 (rightBodyNumber, 90f, 0f);
			
		}
		else if (Input.GetKey(KeyCode.A))
		{
			leftBodyNumber -= 1;
			leftBodyNumber = Mathf.Clamp(leftBodyNumber, -10, 0);

			gameObject.transform.GetChild(2).localEulerAngles = new Vector3(leftBodyNumber, 90f, 0f);
			
		}
		else
		{
			gameObject.transform.GetChild(2).localEulerAngles = new Vector3 (0f, 90f, 0f);
		}
		
		//instruction screen
		if (Input.GetKey(KeyCode.C))
		{
			instructions.SetActive(true);
		}
		else
		{
			instructions.SetActive(false);
		}
		
		
	}
	
	
	void FixedUpdate ()
	{
		BLwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		BRwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FLwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FRwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FLwheel.steerAngle = 80 * Input.GetAxis("Horizontal");
		FRwheel.steerAngle = 80 * Input.GetAxis("Horizontal");
		
		

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
