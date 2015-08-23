using UnityEngine;
using System.Collections;

public class Bag : PickupObject {
	void Start () {

	}

	void Update () {
		// Stop collision between player and bag
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

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
		// Pickup bag
		in_hand = true;
	}

	void OnMouseUp() {
		// Drop bag
		in_hand = false;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Coin") {
			// Update play stats
			Stats.coins_collected++;

			// Remove coin from screen
			Destroy (col.gameObject);
		} else {
			// Drop bag
			in_hand = false;
		}
	}
}
