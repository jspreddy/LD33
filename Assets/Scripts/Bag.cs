using UnityEngine;
using System.Collections;

public class Bag : PickupObject {
	public Player player_script;

	void Start () {
		max_hp = 100;
		hp = max_hp;

		player_script = player.GetComponent<Player>();
	}

	void Update () {
		// Stop collision between player and bag
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

		// Check for user picking up bag
		if (in_hand) {
			follow_mouse ();

			player_script.item_held = this.gameObject;
		} else {
			if(!player.activeSelf) {
				Vector3 current_mouse_pos = transform.position;
				player.transform.position = current_mouse_pos;
			}
		}

		// Death to bag
		if (this.hp <= 0) {
			Object.Destroy(this.gameObject);
		}
	}

	void OnMouseDown() {
		// Pickup bag
		in_hand = true;
		player_script.item_in_hand = true;
	}

	void OnMouseUp() {
		// Drop bag
		in_hand = false;
		player_script.item_in_hand = false;
		player_script.item_held = null;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Coin") {
			// Update play stats
			Stats.coins_collected++;
			Stats.coins_left--;

			// Remove coin from screen
			Destroy (col.gameObject);
		} else {
			// Drop bag
			in_hand = false;
			player_script.item_in_hand = false;
		}
	}
}
