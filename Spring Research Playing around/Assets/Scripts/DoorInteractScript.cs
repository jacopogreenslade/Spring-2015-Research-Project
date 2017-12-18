using UnityEngine;
using System.Collections;

public class DoorInteractScript : MonoBehaviour, InteractiveInterface {

	public bool locked; 
	public bool open;

	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void interact() {
		if (!locked) {
			toggleOpen();
			anim.SetBool("open", open);
		} else {
			// Check for key then open if necessary
		}
	}

	private void toggleOpen() {
		open = !open;
	}
}
