using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits = 1;

	protected int timesHit = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionEnter2D (Collision2D trigger) {
		this.timesHit++;
	}
}
