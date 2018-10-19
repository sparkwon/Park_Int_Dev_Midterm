using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private bool gameHasEnded = false;

	

	public void EndGame()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			GameOver();
			
		}

	}

	public void GameOver()
	{
		SceneManager.LoadScene("game_over");



	}

}
