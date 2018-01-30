using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	public void Start() {
		this.ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if(this.autoPlay) {
			AutoMove();
		} else {
			MoveWithMouse();
		}
	}

	void AutoMove() {
		this.MovePaddle(ball.transform.position.x);
	}

	void MoveWithMouse() {
		this.MovePaddle(Input.mousePosition.x / Screen.width * 16);
	}

	protected void MovePaddle(float xPosition) {
		Vector3 paddlePosition = new Vector3 (
			Mathf.Clamp(
				xPosition,
				0.88f,
				15.16f
			),
			this.transform.position.y,
			this.transform.position.x
		);
		this.transform.position = paddlePosition;
	}
}
