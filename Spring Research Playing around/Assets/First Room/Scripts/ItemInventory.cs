using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemInventory : MonoBehaviour
{

	public List<Item> items = new List<Item> ();
	public List<GameObject> objects = new List<GameObject> ();
	public Transform equipTarget;
	public Transform canvasTransform;
	public Object buttonAsset;
	public int initialOffset = 140;
	public float buttonOffset = 10f;
	public GameObject player;
	public GameObject selectionImage;
	public int selected;

	private ItemDatabase database;
	private bool displayInventory = false;
	private int firstItemHeight;
	private Vector3 lastItemPosition;
	private float lastItemHeigth;
	private Vector3 firstItemPosition;
	private float lastTime;

	void Start ()
	{
		database = GetComponent<ItemDatabase> ();
		foreach (Item item in database.items) {
			items.Add (item);
		}
		lastTime = Time.time;
		canvasTransform.gameObject.SetActive (false);
		firstItemPosition = new Vector3 (canvasTransform.position.x, canvasTransform.position.y + initialOffset, canvasTransform.position.z);
		lastItemPosition = firstItemPosition;
		makeButtons ();
		selected = 0;
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.Tab) && Time.time - lastTime > .1f) {
			displayInventory = !displayInventory;
			lastTime = Time.time;
			//canvasTransform.gameObject.SetActive(false);
		}
		if (displayInventory) {
			canvasTransform.gameObject.SetActive (true);
		} else {
			canvasTransform.gameObject.SetActive (false);
		}

		// TEST
		if (Input.GetKeyDown (KeyCode.Space) && Time.time - lastTime > .1f) {
			lastTime = Time.time;
			addItem (items [0]);
		}
			
		drawSelection(handleSelection());
	}
	// Returns false unless a change has occured
	bool handleSelection() {
		if (Input.GetKeyDown (KeyCode.UpArrow) && Time.time - lastTime > .1f && selected > 0) {
			selected--;
			return true;
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && Time.time - lastTime > .1f && selected < objects.Count) {
			selected++;
			return true;
		}
		return false;
	}

	void drawSelection(bool changed) {
		if (changed) {
			Vector3 newPos = new Vector3(selectionImage.transform.position.x,
				objects[selected].transform.position.y,
				objects[selected].transform.position.z);
			selectionImage.transform.position = newPos;
		}
	}

	void makeButtons ()
	{
		for (int i = 0; i < items.Count; i++) {
			addItem (items [i]);
		}
	}
	/**
	* Returns true if successful pickup and false if not
	*/
	public bool pickUpItem (GameObject obj)
	{
		addItem (items [obj.GetComponent<DatabaseID> ().id]);
		// TODO: in case it goes wrong return false
		return true;
	}

	void addItem (Item i)
	{
		// Check if there already is a similar object
		Transform child = canvasTransform.FindChild (i.name);
		if (child != null) {
			child.GetComponent<UI_Item> ().createItem (i);
		} else {
			// First time creation
			GameObject button = (GameObject)GameObject.Instantiate (buttonAsset, lastItemPosition, canvasTransform.rotation);
			button.name = i.name;
			button.transform.parent = canvasTransform;
			button.GetComponent<UI_Item> ().createItem (i);
			objects.Add(button);
			lastItemPosition.y -= buttonOffset;
		}
	}

	void dropItem() {
		
	}

	//	void OnGUI ()
	//	{
	//		// Make container
	//		if (displayInventory) {
	//			player.GetComponent<FirstPersonController> ().suspendMovement ();
	//			GUI.skin.box.padding = new RectOffset (4, 4, 4, 4);
	//			GUI.skin.box.margin = new RectOffset (4, 4, 4, 4);
	//			GUI.skin.button.alignment = TextAnchor.MiddleLeft;
	//			GUI.Box (new Rect (10, 10, Screen.width - 10, Screen.height - 10), "Inventory");
	//			for (int i = 0; i < items.Count; i++) {
	//				int y = i * 22 + 34 + i * 20;
	//				Rect r = new Rect (20, y, Screen.width - 170, 30);
	//
	//				createItemButtons (y, i);
	//				if (GUI.Button (r, items [i].name)) {
	//					Debug.Log ("The " + items [i].name + " was pressed!");
	//				}
	//			}
	//		} else {
	//			player.GetComponent<FirstPersonController> ().activateMovement ();
	//		}
	//	}
	//
	//	public void addItemFromGameObject (GameObject obj)
	//	{
	//		// Find right item in ItemDatabase
	//		// Then add it
	//		int id = obj.GetComponent<DatabaseID> ().id;
	//		items.Add (database.items [id]);
	//	}
	//
	//	// Makes the small square buttons on items
	//	private void createItemButtons (int y, int index)
	//	{
	//		// Remove item
	//		if (GUI.Button (new Rect (Screen.width - 35, y, 25, 30), "X")) {
	//			if (items [index].instance != null) {
	//				Destroy (items [index].instance, 0f);
	//			}
	//			items.RemoveAt (index);
	//		}
	//		// Equip item
	//		GUI.DrawTexture (new Rect (Screen.width - 150, y - 5, 45, 45), items [index].icon);
	//
	//		Rect r = new Rect (Screen.width - 105, y, 70, 30);
	//		if (!items [index].equipped) {
	//			if (GUI.Button (r, "Equip")) {
	//				items [index].equipped = true;
	//				if (items [index].asset)
	//					items [index].instance = (GameObject)Instantiate (items [index].asset, equipTarget.position, equipTarget.rotation);
	//
	//			}
	//		} else {
	//			if (GUI.Button (r, "Equipped")) {
	//				items [index].equipped = false;
	//				Destroy (items [index].instance, 0f);
	//			}
	//		}
	//	}

}