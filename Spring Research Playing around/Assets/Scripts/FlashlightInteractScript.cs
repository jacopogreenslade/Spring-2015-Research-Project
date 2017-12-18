using UnityEngine;
using System.Collections;
using System;

public class FlashlightInteractScript : MonoBehaviour, InteractiveInterface {

  public Transform flashlightTransform;
  public Light flashlight;

  public void interact () {
    Debug.Log("flash interact");
    transform.position = flashlightTransform.position;
    transform.rotation = flashlightTransform.rotation;
    flashlight.enabled = true;
    transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
  }
}
