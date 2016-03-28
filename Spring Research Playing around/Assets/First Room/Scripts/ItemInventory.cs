using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour {

	public List<Item> items = new List<Item>();

	private ItemDatabase database;

	void Start() {
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		items.Add(database.items[0]);
		items.Add(database.items[1]);
	}

	void OnGUI() {
		foreach (Item item in items) {
			GUI.Label(new Rect(10, item.id * 10 + 10, 200, 50), item.name);
		}
	}

}
