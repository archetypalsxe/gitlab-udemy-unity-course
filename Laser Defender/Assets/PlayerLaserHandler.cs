using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserHandler : MonoBehaviour {

	public float projectileSpeed;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
	}

	// Update is called once per frame
	void Update () {
	}
}
