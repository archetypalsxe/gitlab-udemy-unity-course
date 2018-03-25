using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

	public float projectileSpeed = -1;
	public float damage = -1f;

	// Use this for initialization
	public void Start () {
    this.checkDefaults();
		this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
	}

  public float GetDamage() {
    return this.damage;
  }

  public void Hit() {
    Destroy(this.gameObject);
  }

  protected abstract void checkDefaults();
}
