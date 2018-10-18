using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a capsule with a Rigidbody
// this should handle mouselook as well as WASD movement
public class betterMouseLook : MonoBehaviour
{

	public float lookSpeed = 300f;
	
	//FOR BETTER MOUSE LOOK
	private float upDownRotation; //sore mouse y rotation in this variable and clamp it
	
	// Update is called once per frame, this is where INPUT and RENDERING happens!!!
	void Update()
	{
		// mouse look

		// mouseDelta = difference, how fast you're moving your mouse
		// if it's "0" that means the mouse isn't moving
		// this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta

		// negative mouseX = moving your mouse to the left, etc.
		// negative mouseY = moving your mouse downwards, etc.

		// "pitch yaw roll", X Y Z
		// rotating on X axis, up/down, is "pitch"
		// rotating on Y axis, left/right, is "yaw"
		// rotating on Z axis is "roll"

		// simplest possible mouse-look: just rotate camera naively
		// Camera.main.transform.Rotate(-mouseY, mouseX, 0f);

		// slightly better mouse-look:
		// rotate capsule left/right, but rotate camera up/down
		transform.Rotate(0f, mouseX, 0f); // capsule rotation

		// Camera.main.transform.Rotate(-mouseY, 0f, 0f); // this is the same thing as the line above

		// BETTER MOUSE LOOK add mouseinput to upDownRotation AND clamp upDownRotation
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); //clamp vertical look rotation between -80/80

		// APPLY ROTATION
		// this is what we want to do, but can't: Camera.main.transform.localEulerAngles.z = 0f;
		Camera.main.transform.localEulerAngles = new Vector3(
			upDownRotation,
			0f,
			0F
		);

		//BETTER MOUSE LOOK: LOCK AND HIDE THE MOUSE CURSOR
		//important: do this when the player clicks
		if (Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked; //lock cursor to center of the screen
			Cursor.visible = false; //hides the cursor too just to be safe
		}




	}
}