using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
	public int quantity = 0;

	public void createItem (Item item)
	{
		GameObject textObj = transform.GetChild (0).gameObject;
		quantity ++;
		if (textObj != null) {
			if (quantity > 1) {
				textObj.GetComponent<Text> ().text = item.name + "(" + quantity + ")";
			} else {
				textObj.GetComponent<Text> ().text = item.name;
			}
		}
	}

	public void removeItem(Item item) {
		if (quantity > 1) {
			quantity --;
			transform.GetChild (0).gameObject.GetComponent<Text> ().text = item.name + "(" + quantity + ")";
		} else {
			GameObject.Destroy(transform.gameObject);
		}
	}
}
