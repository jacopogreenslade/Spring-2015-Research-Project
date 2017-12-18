using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public string name;
	public bool selected;
	public bool equipped;
	public Object asset;
	public GameObject instance;
	public string description;
	public Texture2D icon;

}