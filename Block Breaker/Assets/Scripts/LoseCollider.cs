using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;

	public void OnTriggerEnter2D (Collider2D trigger) {
		this.levelManager.LoadLevel("Lose");
	}
}
