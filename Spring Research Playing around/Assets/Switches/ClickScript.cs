using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickScript : MonoBehaviour
{

  public List<PressScript> switches;
  public GameObject lights;
  public Material m;
  public Texture tex;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject hitObj = castPointAtRay ();
		if (Input.GetMouseButtonDown(0) && hitObj != null) {
			hitObj.GetComponent<PressScript>().pressSwitch();
      if (check()) {
        GetComponent<Camera>().enabled = false;
        lights.GetComponent<LightControlScript>().toggleLights();
        m.SetColor("_EmissionColor", Color.white);
      }
		}
	}

  public bool check () {
    foreach (PressScript s in switches) {
      if (!s.active) {
        return false;
      }
    }
    return true;
  }

	private GameObject castPointAtRay ()
	{
		RaycastHit hit;
		Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 5f)) {
			return hit.transform.gameObject;
		}
		return null;
	}
}
