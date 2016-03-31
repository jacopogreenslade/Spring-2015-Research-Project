using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* Takes care of triggering Player interactions with anything. 
* This should not care what the player is interacting with or whether
* they can or not.
*/
public class PlayerInteractScript : MonoBehaviour
{

	public Image dot;
	public ItemInventory inventory;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// TODO: Right now PlayerInteractScript is checking stuff about the object.
		// 		Ideally it should just call interact on it and 
		GameObject hitObj = castPointAtRay ();
		if (hitObj != null && hitObj.tag == "Pickup") {
			//ItemScript script = hitObj.GetComponent<ItemScript>();
			dot.color = Color.black;
			if (Input.GetMouseButtonDown (0)) {
				// This is where you add an item
				if (inventory.pickUpItem (hitObj)) {
					GameObject.Destroy(hitObj);
					// TODO: Display something
				};

			}
		}

	}

	void Interact (ItemScript script)
	{
		script.Interact ();
	}

	/**
	* If the object can be interacted with return true
	*/
	public bool canInteract (ItemScript obj)
	{
		return obj.isInteractive ();
	}

	/**
	*	Returns a 
	*/
	private GameObject castPointAtRay ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		if (Physics.Raycast (ray, out hit, 1f)) {
			return hit.transform.gameObject;
		}
		return null;
	}



}