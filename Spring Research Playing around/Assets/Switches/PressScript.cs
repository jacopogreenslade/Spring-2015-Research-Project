using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressScript : MonoBehaviour
{

	public List<GameObject> switches;

	private bool active;
	private Material mat;
	private float lastTime;

	// Use this for initialization
	void Start ()
	{
		active = false;
		mat = GetComponent<Renderer> ().material;
		//mat.EnableKeyword ("_EMISSION");
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	// If pressed: activate it and all related buttons or
	// deactivate just the one (also look at this again)
	public void pressSwitch ()
	{
		if (Time.time - lastTime > .05f) {
			Debug.Log ("button pressed");
			toggleActive();
			foreach (GameObject g in switches) {
				g.GetComponent<PressScript> ().toggleActive ();
			}
			lastTime = Time.time;
		}
	}

	private void updateColor() {
		if (active) {
			mat.color = Color.white;
		} else {
			mat.color = Color.blue;
		}
	}

	// This should fix the circular call issue
	public void toggleActive() {
		active = !active;
		updateColor();
	}
}
