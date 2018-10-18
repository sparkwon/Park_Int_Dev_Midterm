using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Debug.Log("RESTART");
			SceneManager.LoadScene("bicycle_level");
		}
	}
}
