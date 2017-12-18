using UnityEngine;
using System.Collections;

/**
 * This class creates a RayCast from the start_point to the end_point
 * It aslo can create a point upon collision
 **/
public class RemoteRayScript : MonoBehaviour {

	// Private
	public Transform startT = null;
	public Transform endT = null;
	public GameObject hitMarker = null;

	public bool showRay = true;
	public bool showCollision = true;

	// Public
	private GameObject debugSphere;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		hitMarker.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		hasHit();
	}

	public RaycastHit hasHit() {
		Vector3 direction = endT.position - startT.position;
		
		bool hasHit = Physics.Raycast (startT.position, direction, out hit, direction.magnitude);

		if (!hasHit) {
			return hit;
		}

		if (showRay)
			Debug.DrawLine (startT.position, endT.position, Color.red);
		
		if (hasHit && showCollision) {
			hitMarker.SetActive(true);
			hitMarker.transform.position = hit.point;
			hitMarker.transform.rotation = Quaternion.LookRotation(hit.normal);
		} else {
			hitMarker.SetActive(false);
		}
		return hit;
	}
}
