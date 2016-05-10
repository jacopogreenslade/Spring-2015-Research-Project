using UnityEngine;
using System.Collections;

public class SwitchCamScript : MonoBehaviour {

  public static void switchCamera (Camera cam1, Camera cam2) {
    cam1.enabled = false;
    cam2.enabled = true;
  }


}
