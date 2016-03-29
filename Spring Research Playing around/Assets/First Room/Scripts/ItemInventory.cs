using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemInventory : MonoBehaviour {

	public List<Item> items = new List<Item>();
  public Transform equipTarget;

	private ItemDatabase database;
  private int selection = 0;
  private bool displayInventory = false;
  public GameObject player;

  private float lastTime;

	void Start() {
		database = GetComponent<ItemDatabase>();
    foreach (Item item in database.items) {
      items.Add(item);
    }
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
      player.GetComponent<FirstPersonController>().suspendMovement();
      GUI.skin.box.padding = new RectOffset(4, 4, 4, 4);
      GUI.skin.box.margin = new RectOffset(4, 4, 4, 4);
      GUI.skin.button.alignment = TextAnchor.MiddleLeft;
      GUI.Box(new Rect(10, 10, Screen.width - 10, Screen.height - 10), "Inventory");
      for (int i = 0; i < items.Count; i++) {
        int y = i * 22 + 34 + i * 20;
        Rect r = new Rect(20, y, Screen.width - 170, 30);
        // TODO: move this into the method. It's cluttering shit up!
        createItemButtons(y, i);
        if (GUI.Button(r, items[i].name)) {
          Debug.Log("The " + items[i].name + " was pressed!");
        }
      }
    } else {
      player.GetComponent<FirstPersonController>().activateMovement();
    }
	}

  public void addItemFromGameObject (GameObject obj) {
    // Find right item in ItemDatabase
    // Then add it
    int id = obj.GetComponent<DatabaseID>().id;
    items.Add(database.items[id]);
  }

  // Makes the small square buttons on items
  private void createItemButtons (int y, int index) {
    // Remove item
    if (GUI.Button(new Rect(Screen.width - 35, y, 25, 30), "X")) {
      if (items[index].instance != null) {
        Destroy(items[index].instance, 0f);
      }
      items.RemoveAt(index);
    }
    // Equip item
    GUI.DrawTexture(new Rect(Screen.width - 150, y - 5, 45, 45), items[index].icon);

    Rect r = new Rect(Screen.width - 105, y, 70, 30);
    if (!items[index].equipped) {
      if (GUI.Button(r, "Equip")) {
        items[index].equipped = true;
        if (items[index].asset)
          items[index].instance =(GameObject) Instantiate(items[index].asset, equipTarget.position, equipTarget.rotation);

      }
    } else {
      if (GUI.Button(r, "Equipped")) {
        items[index].equipped = false;
        Destroy(items[index].instance, 0f);
      }
    }
  }

}