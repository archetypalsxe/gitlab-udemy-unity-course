using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 150f;

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
}
