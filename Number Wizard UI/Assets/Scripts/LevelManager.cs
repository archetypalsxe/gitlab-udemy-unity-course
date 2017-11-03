using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Load up the requested level
	public void LoadLevel(string name) {
		Debug.Log("Level load requested: "+ name);
		SceneManager.LoadScene(name);
	}

	// Quit the game
	public void ExitGame() {
		Debug.Log("Requested has been recevied to exit the game");
		Application.Quit();
	}
}
