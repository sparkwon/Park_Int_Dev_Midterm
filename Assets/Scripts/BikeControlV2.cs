using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BikeControlV2 : MonoBehaviour
{
	public WheelCollider FLwheel;
	public WheelCollider FRwheel;
	public WheelCollider BLwheel;
	public WheelCollider BRwheel;
	public float maxTorque = 50f;
	public Rigidbody rb;
	
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Vector3 temp = rb.centerOfMass;
		temp.y = -0.9f;
		rb.centerOfMass = temp;
		
	}
	
	
	void FixedUpdate ()
	{
		BLwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		BRwheel.motorTorque = maxTorque * Input.GetAxis("Vertical");
		FLwheel.steerAngle = 30 * Input.GetAxis("Horizontal");
		FRwheel.steerAngle = 30 * Input.GetAxis("Horizontal");

	}
}
