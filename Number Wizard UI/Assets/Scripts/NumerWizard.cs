using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumerWizard : MonoBehaviour {

	public Text guessText;

	protected int max = 1000;
	protected int min = 1;
	protected int nextGuess;
	protected int numGuesses = 1;
	protected int maxGuessesAllowed = 5;

	public void GuessHigher(){
		this.min = this.nextGuess;
		NextGuess();
	}

	public void GuessLower() {
		this.max = this.nextGuess;
		NextGuess();
	}

	protected void calculateNextGuess() {
		this.nextGuess = Random.Range(this.min, this.max + 1);
		//this.nextGuess = (this.min + this.max) / 2;
	}

	protected void updateGuessText() {
		this.guessText.text = this.nextGuess.ToString();
	}

	protected void NextGuess() {
		if(this.numGuesses >= this.maxGuessesAllowed) {
			SceneManager.LoadScene("Win");
		}
		calculateNextGuess();
		this.numGuesses++;
		this.updateGuessText();
	}

	// Use this for initialization
	void Start () {
		this.calculateNextGuess();
		this.updateGuessText();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			GuessHigher();
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			GuessLower();
		}
	}
}
