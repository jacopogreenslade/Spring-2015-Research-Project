using UnityEngine;
using System.Collections;

public class LockedState : MonoBehaviour, LockStateInterface {

	public void activateBehavior () {
		Debug.Log("Successful Interaction!!!!");
	}

	public bool isLocked() {
		return true;
	}
	
}