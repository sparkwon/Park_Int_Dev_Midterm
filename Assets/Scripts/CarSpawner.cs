using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public GameObject car;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	
	// Use this for initialization
	void Start () {
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		//int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		//thing to spawn, where to spawn it, and the rotation of the object
		Instantiate(car, spawnPoints[0].position, spawnPoints[0].rotation);
		Instantiate(car, spawnPoints[1].position, spawnPoints[1].rotation);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
