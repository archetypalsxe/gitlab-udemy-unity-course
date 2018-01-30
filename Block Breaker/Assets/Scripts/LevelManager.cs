using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Load up the requested level
	public void LoadLevel(string name) {
		this.resetBrickCount();
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel() {
		this.resetBrickCount();
		SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
	}

	// Quit the game
	public void ExitGame() {
		Application.Quit();
	}

	public void BrickDestroyed() {
		if(Brick.brickCount <= 0) {
			this.LoadNextLevel();
		}
	}

	private void resetBrickCount() {
		Brick.brickCount = 0;
	}
}
