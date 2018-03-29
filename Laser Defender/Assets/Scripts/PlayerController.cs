using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 8f;
	public float boundaryPadding = 0.6f;
	public GameObject laserPrefab;
	public float fireRate = 0.2f;
	public float health = 100f;

	protected float laserDistance = 0.6f;
	protected float xMinimum;
	protected float xMaximum;
	protected float yMinimum;
	protected float yMaximum;

	public void OnTriggerEnter2D (Collider2D collision) {
		EnemyLaser laser = collision.gameObject.GetComponent<EnemyLaser>();
		if(laser != null) {
			this.health -= laser.GetDamage();
			laser.Hit();
			if (health <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 minBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
		Vector3 maxBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cameraDistance));
		this.xMinimum = minBoundary.x + this.boundaryPadding;
		this.xMaximum = maxBoundary.x - this.boundaryPadding;
		this.yMinimum = minBoundary.y + this.boundaryPadding;
		this.yMaximum = maxBoundary.y - this.boundaryPadding;
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

		this.checkBoundaries();

		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("generateLaser", 0f, fireRate);
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("generateLaser");
		}
	}

	protected void generateLaser() {
		Instantiate(
			this.laserPrefab,
			this.transform.position + Vector3.up * this.laserDistance,
			Quaternion.identity
		);
	}

	protected void checkBoundaries() {
		this.transform.position = new Vector3 (
			Mathf.Clamp(
				this.transform.position.x,
				this.xMinimum,
				this.xMaximum
			),
			Mathf.Clamp(
				this.transform.position.y,
				this.yMinimum,
				this.yMaximum
			),
			this.transform.position.z
		);
	}

	protected void moveUp() {
		this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
	}

	protected void moveDown() {
		this.transform.position += Vector3.down * this.movementSpeed * Time.deltaTime;
	}

	protected void moveLeft() {
		this.transform.position += Vector3.left * this.movementSpeed * Time.deltaTime;
	}

	protected void moveRight() {
		this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
	}
}
