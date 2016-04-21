using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DissapearScript : MonoBehaviour {

  public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter () {
    text.CrossFadeAlpha(0.0f, 1.0f, false);
  }

}
