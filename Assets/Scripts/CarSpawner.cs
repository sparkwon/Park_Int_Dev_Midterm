using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public GameObject car;
	public float spawnTime = 2.5f;
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
		Instantiate(car, spawnPoints[2].position, spawnPoints[2].rotation);
		Instantiate(car, spawnPoints[3].position, spawnPoints[3].rotation);
		Instantiate(car, spawnPoints[4].position, spawnPoints[4].rotation);
		Instantiate(car, spawnPoints[5].position, spawnPoints[5].rotation);
		Instantiate(car, spawnPoints[6].position, spawnPoints[6].rotation);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
