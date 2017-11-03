using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumerWizard : MonoBehaviour {

	public Text guessText;

	protected int max;
	protected int min;
	protected int numGuesses = 1;
	protected int maxGuessesAllowed = 5;

	public void GuessHigher(){
		this.min = (this.min + this.max) / 2;
		NextGuess();
	}

	public void GuessLower() {
		this.max = (this.min + this.max) / 2;
		NextGuess();
	}

	protected void updateGuessText() {
		this.guessText.text = ((this.min + this.max) / 2).ToString();
	}

	protected void NextGuess() {
		if(this.numGuesses >= this.maxGuessesAllowed) {
			SceneManager.LoadScene("Win");
		}
		this.numGuesses++;
		this.updateGuessText();
	}

	// Use this for initialization
	void Start () {
		this.max = 1000;
		this.min = 1;
		this.max++;
		this.min--;
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
