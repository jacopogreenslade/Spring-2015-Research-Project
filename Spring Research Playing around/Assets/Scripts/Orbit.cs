using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{

	private GameObject target_Obj;
	public Transform target;
	public int radius = 3;
	public float speed = 1.0f;

	// Use this for initialization
	// Use this for initialization
	void Start ()
	{
		if (!target) {
			target_Obj = new GameObject ("target");
			target = target_Obj.transform;
			target.position = transform.position;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// Get the relative position by subtracting Vectors
		// To make up for the height difference Use this Vector
		Vector3 height = new Vector3 (0, transform.position.y - target.position.y, 0);

		Vector3 relPos = (target.position + height) - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relPos);

		Quaternion current = transform.localRotation;

		transform.localRotation = Quaternion.Slerp (current, rotation, Time.deltaTime * speed);
		transform.Translate (0, 0, radius * Time.deltaTime);
	}
}
