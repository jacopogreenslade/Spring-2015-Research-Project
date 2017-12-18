using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public Transform lastSpawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void respawn() {
		transform.position = lastSpawnPoint.position;
	}

	public void setLastSpawnPoint(Transform newSpawnPoint) {
		lastSpawnPoint = newSpawnPoint;
	}
}
