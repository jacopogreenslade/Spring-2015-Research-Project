using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour {

	private const float speed = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float factor = Mathf.Sin(Time.time * speed);
		factor = 0.002f * (factor + .5f);
		transform.Translate(new Vector3(0, 0, factor));
	}
}
