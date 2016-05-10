using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TerminalInteractScript : MonoBehaviour, InteractiveInterface
{

	public Transform canvas;

	private bool activated = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter ()
	{
		
	}

	public void interact ()
	{
		if (!activated) {
			canvas.transform.FindChild ("Start Text").GetComponent<Text> ().enabled = false;
			canvas.transform.FindChild ("Enter Text").GetComponent<Text> ().enabled = true;
			activated = true;
		} else {
			// Call effect script
			// Pause movement
			Camera.main.GetComponent<PixelateRenderTextureScript>().startEffect();
			StartCoroutine(Wait());
		}

	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (12.0f);
		SceneManager.LoadScene (1);
	}


}
