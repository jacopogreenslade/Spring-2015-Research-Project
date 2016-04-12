using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "objectProps", menuName = "Scriptable Objects/Object Properties", order = 1)]

public class ObjectPropertiesSO : ScriptableObject {
	public bool interactive = false;
	public string name = "Object Name";
	public string description = "Brief description of an object";
}