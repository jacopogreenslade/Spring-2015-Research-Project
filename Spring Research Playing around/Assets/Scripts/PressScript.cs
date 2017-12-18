using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressScript : MonoBehaviour
{

	public List<GameObject> switches;

	public bool active;
	private Material mat;
	private float lastTime;
  

  private float offXRot = 294.0f;
  private float onXRot = 243.0f;

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

  private void toggleRotation () {
    if (active) {
      transform.localEulerAngles = new Vector3(onXRot, 0f, 0f);
    } else {
      transform.localEulerAngles = new Vector3(offXRot, 0f, 0f);
    }
    }

	// This should fix the circular call issue
	public void toggleActive() {
		active = !active;
		toggleRotation();
	}
}
