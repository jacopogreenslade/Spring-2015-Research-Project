using UnityEngine;
using System.Collections;

public class SwitchPuzzleInteractScript : MonoBehaviour, InteractiveInterface {

  public Camera cam;

  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      cam.enabled = false;
      GetComponent<BoxCollider>().enabled = true;
    }
  }

  public void interact () {
    //SwitchCamScript.switchCamera(Camera.main, cam);
    cam.enabled = true;
    transform.parent.GetComponent<ClickScript>().enabled = true;
    GetComponent<BoxCollider>().enabled = false;
  }

}
