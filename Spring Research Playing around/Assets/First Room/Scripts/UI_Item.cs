using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Item : MonoBehaviour
{
	public int quantity = 0;
	private Transform playerTransform;
	private GameObject inventory;
	private GameObject selection;
	private ItemInventory invScript;

	void Start ()
	{
		// Find the selectionImage obj
		selection = GameObject.Find ("SelectionImage").gameObject;
		inventory = GameObject.Find ("Inventory Holder").gameObject;
		invScript = inventory.GetComponent<ItemInventory> ();

		makeTriggers ();
	}

	void makeTriggers ()
	{
		EventTrigger trigger = GetComponent<EventTrigger> ();

		// Mouseover
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener ((eventData) => {
			selection.GetComponent<SelectPositionScript> ().positionOverItem (this.gameObject);
			invScript.setSelected (this.gameObject);
		});
		trigger.triggers.Add (entry);

		// OnClick
		EventTrigger.Entry click = new EventTrigger.Entry ();
		click.eventID = EventTriggerType.PointerClick;
		click.callback.AddListener ((eventData) => {
			removeItem (invScript.items [invScript.getSelected ()]);
		});
		trigger.triggers.Add (click);
	}

	public void createItem (Item item)
	{
		GameObject textObj = transform.GetChild (0).gameObject;
		quantity++;
		if (textObj != null) {
			if (quantity > 1) {
				textObj.GetComponent<Text> ().text = item.name + "(" + quantity + ")";
			} else {
				textObj.GetComponent<Text> ().text = item.name;
			}
		}
	}

	public void removeItem (Item item)
	{
		if (quantity > 1) {
			quantity--;
			transform.GetChild (0).gameObject.GetComponent<Text> ().text = item.name + "(" + quantity + ")";
		} else {
			invScript.items.Remove(item);
			invScript.drawInventory();
			// make a redraw functions
			//GameObject.Destroy (this.gameObject);
			GameObject.Instantiate(item.asset, Camera.main.transform.position + new Vector3(-2, 0, 0), Camera.main.transform.rotation);
		}
	}
}
