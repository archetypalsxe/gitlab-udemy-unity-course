using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	protected Paddle paddle;

	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		this.paddle = GameObject.FindObjectOfType<Paddle>();
		this.paddleToBallVector =
			this.transform.position - this.paddle.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(!this.hasStarted) {
			// Move the ball with the paddle
			this.transform.position =
				this.paddle.transform.position + this.paddleToBallVector;

			if(Input.GetMouseButtonDown(0)) {
				this.hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
