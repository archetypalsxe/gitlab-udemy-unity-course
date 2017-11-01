using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerWizards : MonoBehaviour {

	protected int max;
	protected int min;
	protected int numGuesses;

	// Use this for initialization
	void Start () {
		this.max = 1000;
		this.min = 1;

		this.numGuesses = 1;
		print("Welcome to Number Wizard!");
		print("Pick a number in your head ("+ this.min +"-"+ this.max +"), but don't tell me!");
		this.max++;
		this.min--;
		this.displayPrompt();

		print("Up for higher, down for lower, return means we got it!");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			this.min = (this.min + this.max) / 2;
			this.displayPrompt();
			this.numGuesses++;
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			this.max = (this.min + this.max) / 2;
			this.displayPrompt();
			this.numGuesses++;
		} else if(Input.GetKeyDown(KeyCode.Return)) {
			print("We got it in "+ this.numGuesses +" guesses!");
		}
	}

	protected void displayPrompt() {
		print("Is the number higher or lower than "+ (this.min + this.max) / 2 +"?");
	}
}
