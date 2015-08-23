using UnityEngine;
using System.Collections;

public class Weapon : Object {
	public Player player_script;
	public int damage = 10;

	void Start () {
		player_script = player.GetComponent<Player>();
	}

	void Update () {
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

		// Check for user picking up knife
		if (in_hand) {
			player_script.item_held = this.gameObject;

			follow_mouse ();
		} else {
			if(!player.activeSelf) {
				Vector3 current_mouse_pos = transform.position;
				player.transform.position = current_mouse_pos;
			}
		}
	}

	void OnMouseDown() {
		// Pickup knife
		in_hand = true;
		player_script.item_in_hand = true;
	}
	
	void OnMouseUp() {
		// Drop knife
		in_hand = false;
		player_script.item_in_hand = false;
		player_script.item_held = null;
	}
}
