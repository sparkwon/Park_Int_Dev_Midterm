using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour {
	private Rigidbody rBody;
	
	public float moveSpeed = 0f;
	public GameObject car;
	
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();
		moveSpeed = Random.Range(1, 8);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void FixedUpdate()
	{
		rBody.AddForce(transform.forward * moveSpeed);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "carDestroyer")
		{
			Destroy(car);
		}
	}
}
