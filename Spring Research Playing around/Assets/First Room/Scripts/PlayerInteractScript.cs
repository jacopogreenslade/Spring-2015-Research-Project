using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* Takes care of triggering Player interactions with anything. 
* This should not care what the player is interacting with or whether
* they can or not.
*/
public class PlayerInteractScript : MonoBehaviour {

	public Image dot;
  public ItemInventory inventory;
	private Transform cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Look at section
		GameObject hitObj = castPointAtRay();
		if (hitObj != null && hitObj.tag == "Pickup") {
			//ItemScript script = hitObj.GetComponent<ItemScript>();
			dot.color = Color.black;
      if (Input.GetMouseButtonDown(0)) {
        inventory.addItemFromGameObject(hitObj);
      }
			//if (script.isInteractive()) {
			//	if (Input.GetMouseButtonDown(0)) {
			//		Interact(script);
			//	}
			//	dot.color = Color.green;
			//} else {
				
			//}
			
		}


	}

	void Interact (ItemScript script) {
		script.Interact();
	}

	/**
	* If the object can be interacted with return true
	*/
	public bool canInteract (ItemScript obj) {
		return obj.isInteractive();
	}
	
	/**
	*	Returns a 
	*/
	private GameObject castPointAtRay() {
		RaycastHit hit;
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out hit, 100f)) {
			return hit.transform.gameObject;
		}
		return null;
	}



}