using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 8f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)) {
			this.moveUp();
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			this.moveDown();
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			this.moveLeft();
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			this.moveRight();
		}
	}

	protected void moveUp() {
		this.movePlayer(0, 1);
	}

	protected void moveDown() {
		this.movePlayer(0, -1);
	}

	protected void moveLeft() {
		this.movePlayer(-1, 0);
	}

	protected void moveRight() {
		this.movePlayer(1, 0);
	}

	protected void movePlayer(float xDifferential, float yDifferential) {
		this.transform.position = new Vector3 (
			Mathf.Clamp(
				this.transform.position.x + (xDifferential * this.movementSpeed * Time.deltaTime) ,
				-5.5f,
				5.5f
			),
			Mathf.Clamp(
				this.transform.position.y + (yDifferential * this.movementSpeed * Time.deltaTime),
				-4.5f,
				4.5f
			),
			this.transform.position.x
		);
	}
}
