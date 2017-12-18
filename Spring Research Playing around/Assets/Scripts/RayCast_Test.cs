using UnityEngine;
using System.Collections;

public class RayCast_Test : MonoBehaviour
{
	// Public
	public RaycastHit hit;
	public Transform target;

	// Private
	private Vector3 hitInitialPosition;
	private GameObject debugSphere;

	// Use this for initialization
	void Start ()
	{
		hitInitialPosition = new Vector3(100, 100, 100);

		debugSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		debugSphere.GetComponent<SphereCollider>().enabled = false;
		debugSphere.transform.localScale = new Vector3(.3f, .3f, .3f);

	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = target.position - transform.position;

		if (Physics.Raycast (transform.position, direction, out hit, 3)) {
			Debug.DrawLine (transform.position, hit.point, Color.red);
			if (debugSphere) {
				debugSphere.SetActive(true);
				debugSphere.transform.position = hit.point;
			}
		} else {
			debugSphere.SetActive(false);
		}
	}

}
