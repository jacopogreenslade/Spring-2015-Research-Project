using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppearScript : MonoBehaviour {

  public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter () {
    text.CrossFadeAlpha(1.0f, 0.0f, false);
  }

}
