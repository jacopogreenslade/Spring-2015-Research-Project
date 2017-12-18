using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

	private LockStateInterface currentBehavior;

	private GameObject keyItem;
	private string prompt;

	// Use this for initialization
	void Start () {
		currentBehavior = new LockedState();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/**
	* Is called if player interacts with obj in hand.
	*/
	void Unlock (GameObject key) {
		if (currentBehavior.isLocked() && (keyItem.tag == key.tag)) {
			currentBehavior = new UnlockedState();
		}
	}

	/**
	* Is called if player interacts.
	*/
	void Interact () {
		currentBehavior.activateBehavior();
	}
}
