using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits = 1;

	protected int timesHit = 0;
	protected LevelManager levelManager;

	// Use this for initialization
	void Start () {
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionEnter2D (Collision2D trigger) {
		this.timesHit++;
		if(this.timesHit >= this.maxHits) {
			Destroy(gameObject);
		}
	}
}
