using UnityEngine;
using System.Collections;

public class BinarySwitchScript : MonoBehaviour {

	// The first material should always be the 1s
	public Material[] mats = new Material[2];
	public float switchInterval = 0.3f;

	public bool one;
	private float lastTime;
	private Renderer rend;
	private BoxCollider boxColl;


	// Use this for initialization
	void Start () {
		lastTime = Time.time;
		rend = GetComponent<Renderer>();
		boxColl = GetComponent<BoxCollider>();

		// This initializes the correct material
		one = !one;
		toggleState();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && Time.time - lastTime > switchInterval){
			Debug.Log("Pressed");
			toggleState();
		}
	}

	private void toggleState() {
		one = !one;
		if (one) {
			setOneState();
		} else {
			setZeroState();
		}
	}

	private void setOneState() {
		boxColl.enabled = one;
		rend.material = mats[0];
	}

	private void setZeroState() {
		boxColl.enabled = one;
		rend.material = mats[1];
	}

}
