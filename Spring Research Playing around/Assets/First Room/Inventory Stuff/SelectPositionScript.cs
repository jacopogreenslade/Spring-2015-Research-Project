using UnityEngine;
using System.Collections;

public class SelectPositionScript : MonoBehaviour {

  // takes an item and matches its position on the canvas
  public void positionOverItem (GameObject item) {
    Vector3 newPos = new Vector3(transform.position.x,
        item.transform.position.y,
        item.transform.position.z);
    transform.position = newPos;
  }

}
