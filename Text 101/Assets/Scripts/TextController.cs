using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	protected States currentState;
	protected enum States {cell, mirror, sheets0, lock0, cellMirror, sheets1, lock1, freedom};

	// Use this for initialization
	void Start () {
		this.currentState = States.cell;
	}

	// Update is called once per frame
	void Update () {
		if(this.currentState == States.cell) {
			this.stateCell();
		} else if (this.currentState == States.sheets0) {
			stateSheets0();
		} else if (this.currentState == States.sheets1) {
			stateSheets1();
		} else if (this.currentState == States.lock0) {
			stateLock0();
		} else if (this.currentState == States.lock1) {
			stateLock1();
		} else if (this.currentState == States.mirror) {
			stateMirror();
		} else if (this.currentState == States.cellMirror) {
			stateCellMirror();
		} else if (this.currentState == States.freedom) {
			stateFreedom();
		}
	}

	protected void stateMirror() {
		this.text.text = "The dirty old mirror on the wall seems loose...\n\n"+
			"(T = Take the mirror, R = Return to cell)";
		if(Input.GetKeyDown(KeyCode.T)) {
			this.currentState = States.cellMirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			this.currentState = States.cell;
		}
	}

	protected void stateCell() {
		this.text.text = "You are in a prison cell! There are some dirty sheets on the bed, a mirror on the wall, and a door leading out of your cell.\n\n"+
			"(S = Look at sheets, M = Look at Mirror, L = Investigate Lock)";
		if(Input.GetKeyDown(KeyCode.S)) {
			this.currentState = States.sheets0;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			this.currentState = States.lock0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			this.currentState = States.mirror;
		}
	}

	protected void stateCellMirror() {
		this.text.text = "You are in a prison cell with a mirror in your hand. There are some dirty sheets on the bed, and a door leading out of your cell.\n\n"+
			"(S = Look at sheets, L = Investigate Lock)";
		if(Input.GetKeyDown(KeyCode.S)) {
			this.currentState = States.sheets1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			this.currentState = States.lock1;
		}
	}

	protected void stateSheets0() {
		this.text.text = "You can't believe you sleep in these things! Surely it's time somebody changed them! The pleasures of prison life I guess!\n\n"+
			"(R = Return to roaming your cell)";
		if(Input.GetKeyDown(KeyCode.R)) {
			this.currentState = States.cell;
		}
	}

	protected void stateSheets1() {
		this.text.text = "Holding a mirror doesn't make the sheets look anymore inviting!\n\n"+
			"(R = Return to roaming your cell)";
		if(Input.GetKeyDown(KeyCode.R)) {
			this.currentState = States.cellMirror;
		}
	}

	protected void stateLock0() {
		this.text.text = "It looks like a button lock! If only you knew the combination... If you could see where the dirty fingerprints were, it might help\n\n"+
			"(R = Return to roaming your cell)";
		if(Input.GetKeyDown(KeyCode.R)) {
			this.currentState = States.cell;
		}
	}

	protected void stateLock1() {
		this.text.text = "You carefully put the mirror through the bars and turn it around so you can see the lock! You can make out fingerprints on the buttons. You press the dirty buttons and hear a click!\n\n"+
			"(R = Return to roaming your cell, O = Open the cell door)";
		if(Input.GetKeyDown(KeyCode.R)) {
			this.currentState = States.cellMirror;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			this.currentState = States.freedom;
		}
	}

	protected void stateFreedom() {
		this.text.text = "You are FREE!\n\n"+
			"(P = Play again)";
		if(Input.GetKeyDown(KeyCode.P)) {
			this.currentState = States.cell;
		}
	}
}
