using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	private Camera m_Camera;
	private CharacterController m_CharacterController;
	private float currentTime;

	// Use this for initialization
	void Start () {
		m_Camera = Camera.main;
		m_CharacterController = GetComponent<CharacterController>();
		currentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		print (Time.time - currentTime);
		if (Input.GetKey (KeyCode.Space) && (Time.time - currentTime > 2.0f)) { // Is Jumping
			m_CharacterController.Move(m_CharacterController.transform.position + new Vector3(0.5f, 0, 0));
			currentTime = 0.0f;
		}
	}
}
