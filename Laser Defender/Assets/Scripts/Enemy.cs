using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 150f;
	public GameObject laserPrefab;

	public float minFireRate = 2f;
	public float maxFireRate = 0.5f;
	public float startingDelay = 0f;

	protected float laserDistance = 0.6f;
	protected float timeToFire;

	public void OnTriggerEnter2D (Collider2D collision) {
		PlayerLaserHandler playerLaser = collision.gameObject.GetComponent<PlayerLaserHandler>();
		if(playerLaser != null) {
			this.health -= playerLaser.GetDamage();
			playerLaser.Hit();
			if (health <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	void Start() {
		this.generateRandomFireTime();
		this.timeToFire += this.startingDelay;
	}

	void Update() {
		if(Time.time >= timeToFire) {
			this.generateRandomFireTime();
			this.generateLaser();
		}
	}

	protected void generateRandomFireTime() {
		float range = this.minFireRate - this.maxFireRate;
		float randomPercent = (Random.value / 1);
		this.timeToFire = Time.time + (this.maxFireRate + range * randomPercent);
	}

	protected void generateLaser() {
		Instantiate(
			this.laserPrefab,
			this.transform.position + Vector3.down * this.laserDistance,
			Quaternion.identity
		);
	}
}
