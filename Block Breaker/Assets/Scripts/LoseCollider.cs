using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	protected LevelManager levelManager;

	public void Start() {
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	public void OnTriggerEnter2D (Collider2D trigger) {
		this.levelManager.LoadLevel("Lose");
	}
}
