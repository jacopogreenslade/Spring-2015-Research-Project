using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
		
	public string name;
	public int id;
  public bool selected;
  public bool equipped;
  public GameObject obj;
	public string description;
	public Texture2D icon;

	public Item (string name, int id, string description) {
		
	}

	}