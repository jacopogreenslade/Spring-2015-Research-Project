﻿using UnityEngine;
using System.Collections;

public class DeathColliderScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		player.GetComponent<RespawnScript>().respawn();
	}
}
