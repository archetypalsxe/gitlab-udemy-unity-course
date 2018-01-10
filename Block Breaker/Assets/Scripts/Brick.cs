using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] sprites;
	public static int brickCount;

	protected int timesHit = 0;
	protected LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		this.isBreakable = this.tag == "Breakable";
		if(this.isBreakable) {
			brickCount++;
		}
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionEnter2D (Collision2D trigger) {
		if(this.isBreakable) {
			AudioSource.PlayClipAtPoint(this.crack, transform.position);
			this.HandleHits();
		}
	}

	protected void HandleHits() {
		this.timesHit++;
		if(this.timesHit >= (this.sprites.Length + 1)) {
			brickCount--;
			this.levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadNewSprite();
		}
	}

	protected void LoadNewSprite() {
		if(this.sprites[timesHit - 1]) {
			this.GetComponent<SpriteRenderer>().sprite = this.sprites[timesHit - 1];
		}
	}
}
