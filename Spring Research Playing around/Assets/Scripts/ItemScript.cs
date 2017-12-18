using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	public bool interactive = false;

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

	public bool isInteractive() {
		return interactive;
	}

	/**
	* Is called if player interacts.
	*/
	public void Interact () {
		currentBehavior.activateBehavior();
	}
}
