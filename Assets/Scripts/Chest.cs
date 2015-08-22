using UnityEngine;
using System.Collections;

public class Chest : Object {
	private bool chest_opened;

	void Start () {
		chest_opened = false;
	}

	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log("I clicked that shit");
	}
}
