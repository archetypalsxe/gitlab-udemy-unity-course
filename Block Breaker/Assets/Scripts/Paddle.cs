using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 paddlePosition = new Vector3 (
			Mathf.Clamp(
				Input.mousePosition.x / Screen.width * 16,
				0.5f,
				15.5f
			),
			this.transform.position.y,
			this.transform.position.x
		);
		this.transform.position = paddlePosition;
	}
}
