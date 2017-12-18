using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class MotionScript : MonoBehaviour
{
	// Public
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	public GameObject remoteRayObj;

	// Private
	private bool climbing = false;
	private Vector3 moveTo;

	// Use this for initialization
	void Start ()
	{
		moveTo = new Vector3(transform.position.x, 2f, 1.88f);

		remoteRayObj = GameObject.FindGameObjectWithTag("StepHeightRay");
	}
	
	// Update is called once per frame
	void Update ()
	{
		CharacterController controller = GetComponent<CharacterController> ();
		// Walking state
		if (!climbing) {
			//controller.attachedRigidbody.useGravity = false;
			// We'll say we're in the move_state untill we climb

			//transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
			//Vector3 forward = transform.TransformDirection (Vector3.forward);
			//float curSpeed = speed * Input.GetAxis ("Vertical");
			controller.SimpleMove (Vector3.forward);
		}
		// Climbing state
		if (climbing) {
			//controller.attachedRigidbody.useGravity = false;
			// Get hit position
			// Move to right height first
			Vector3 relDist = moveTo - transform.position;

			if (relDist.magnitude > .5f) {
				relDist = relDist.normalized * 1.5f;
				controller.Move(relDist * Time.deltaTime);
			} else {
				climbing = false;
			}
			// Then to correct pos
		}

	}

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		// If the normal of the surface hit is more or less horizontal
		if (Vector3.Angle (hit.normal, Vector3.up) > 89.0f && Vector3.Angle (hit.normal, Vector3.up) < 91.0f ) {

			Debug.Log ("Hit detected");
			// Call ray to see if there's a flat surface to climb.
			// If there go into climb mode
//			bool rayHit = remoteRayObj.GetComponent<RemoteRayScript>().hasHit();
//
//			if (rayHit) {
//				float heightDifference = rayHit.point.y - transform.position.y;
//				if (heightDifference > GetComponent<CharacterController> ().stepOffset) {
//
//				}
//				climbing = true;
//			}

			// For now
		}
	}
}