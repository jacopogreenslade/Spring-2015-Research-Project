using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour {

	public List<Item> items = new List<Item>();

	private ItemDatabase database;
  private int selection = 0;
  private bool displayInventory = false;

  private float lastTime;

	void Start() {
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    foreach (Item item in database.items) {
      items.Add(item);
    }
    //items.Add(database.items[0]);
    //items.Add(database.items[1]);

    lastTime = Time.time;
	}

  void Update () {
    if (Input.GetKey(KeyCode.Tab) && Time.time - lastTime > .1f) {
      displayInventory = !displayInventory;
      lastTime = Time.time;
    }
  }

	void OnGUI() {
    // Make container
    if (displayInventory) {
      GUI.skin.box.padding = new RectOffset(4, 4, 4, 4);
      GUI.skin.box.margin = new RectOffset(4, 4, 4, 4);
      GUI.skin.button.alignment = TextAnchor.MiddleLeft;
      GUI.Box(new Rect(10, 10, Screen.width - 10, Screen.height - 10), "Inventory");
      for (int i = 0; i < items.Count; i++) {
        int y = i * 22 + 34 + i * 10;
        Rect r = new Rect(20, y, Screen.width - 125, 30);
        // TODO: move this into the method. It's cluttering shit up!
        createItemButtons(y, i);
        if (GUI.Button(r, items[i].name)) {
          Debug.Log("The " + items[i].name + " was pressed!");
        }
      }
    }
	}

  // Makes the small square buttons on items
  void createItemButtons (int y, int index) {
    // Remove item
    if (GUI.Button(new Rect(Screen.width - 35, y, 25, 30), "X")) {
      items.RemoveAt(index);
    }
    // Equip item
    Rect r = new Rect(Screen.width - 105, y, 70, 30);
    if (!items[index].equipped) {
      if (GUI.Button(r, "Equip")) {
        items[index].equipped = true;
        // TODO: to keep the reference of the created object, have an array of equipped items.
        // This will let the database keep the reference to the Prefab and not loose the pointer.
        Instantiate(items[index].obj, transform.position, transform.rotation);

      }
    } else {
      if (GUI.Button(r, "Equipped")) {
        items[index].equipped = false;
        Destroy(items[index].obj, 0f);
      }
    }
  }
}