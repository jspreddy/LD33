using UnityEngine;
using System.Collections;

public class Bag : PickupObject {
	void Start () {
		
	}

	void Update () {
		if (in_hand) {
			follow_mouse ();
		} else {
			if(!player.active) {
				player.active = true;

				Vector3 current_mouse_pos = transform.position;
				player.transform.position = current_mouse_pos;
			}
		}
	}

	void OnMouseDown() {
		in_hand = true;
	}

	void OnMouseUp() {
		in_hand = false;
	}

	void OnCollisionEnter2D(Collision2D col) {
		in_hand = false;
	}
}
