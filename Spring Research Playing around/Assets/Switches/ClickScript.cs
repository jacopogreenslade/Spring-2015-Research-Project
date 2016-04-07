using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour
{

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
		}
	}

	private GameObject castPointAtRay ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 5f)) {
			return hit.transform.gameObject;
		}
		return null;
	}
}
