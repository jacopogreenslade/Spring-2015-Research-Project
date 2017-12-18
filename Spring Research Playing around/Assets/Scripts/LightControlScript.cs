using UnityEngine;
using System.Collections;

public class LightControlScript : MonoBehaviour {

  public Transform lightParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
	}

  public void toggleLights () {
    foreach (Transform child in lightParent) {
      child.GetComponent<Light>().enabled = !child.GetComponent<Light>().enabled;
    }
  }
}
