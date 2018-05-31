using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5;
	public float movementSpeed = 6f;
	public float spawnDelay = 0.5f;

	protected bool goingLeft = true;
	protected float xMinimum;
	protected float xMaximum;
	protected float yMinimum;
	protected float yMaximum;

	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 minBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
		Vector3 maxBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cameraDistance));
		this.xMinimum = minBoundary.x + (this.width / 2);
		this.xMaximum = maxBoundary.x - (this.width / 2);
		this.yMinimum = minBoundary.y + (this.height / 2);
		this.yMaximum = maxBoundary.y - (this.height / 2);

		this.generateEnemiesUntilFull();
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(
			transform.position,
			new Vector3 (this.width, this.height)
		);
	}

	// Update is called once per frame
	void Update () {
		if(this.AllMembersDead()) {
			this.generateEnemiesUntilFull();
		}
		if(this.goingLeft) {
			this.transform.position += Vector3.left * this.movementSpeed * Time.deltaTime;
		} else {
			this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
		}
		this.checkBoundaries();
	}

	protected void generateEnemiesUntilFull() {
		Debug.Log("Generating enemy fuction");
		Transform freePosition = this.NextFreePosition();
		if(freePosition) {
			Debug.Log("Spawning enemy: " + freePosition);
			GameObject enemy = Instantiate(
				enemyPrefab,
				freePosition.transform.position,
				Quaternion.identity
			) as GameObject;
			enemy.transform.parent = freePosition;
			Invoke("generateEnemiesUntilFull", this.spawnDelay);
			Debug.Log("Invoked!");
		} else {
			Debug.Log("No free positions");
		}
	}

	protected void generateEnemies() {
		foreach(Transform child in this.transform) {
			GameObject enemy = Instantiate(
				enemyPrefab,
				child.transform.position,
				Quaternion.identity
			) as GameObject;
			enemy.transform.parent = child;
		}
	}

	protected void checkBoundaries() {
		if(
			this.transform.position.x > this.xMaximum ||
			this.transform.position.x < this.xMinimum
		) {
			this.goingLeft = !this.goingLeft;
		}
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

	protected Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	protected bool AllMembersDead() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
