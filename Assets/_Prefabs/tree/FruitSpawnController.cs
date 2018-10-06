using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnController : MonoBehaviour {
public bool Occupied;
	// Use this for initialization
	void Start () {
		
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Food"){
			Occupied = true;
		}
	}
	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Food"){
			Occupied = false;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
