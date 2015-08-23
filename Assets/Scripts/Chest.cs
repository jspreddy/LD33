using UnityEngine;
using System.Collections;

public class Chest : Object {
	private bool chest_opened;
	private float speed = 6f;

	public Rigidbody2D coin;

	void Start () {
		chest_opened = false;
	}

	void Update () {
	
	}

	void OnMouseDown() {
		if (!chest_opened) {
			chest_opened = true;

			generate_coins(12);
		}
	}

	void generate_coins(int num_coins) {
		for (int i = 0; i < num_coins; i++) {
			Rigidbody2D coin_clone = (Rigidbody2D) Instantiate(coin, this.transform.position, transform.rotation);
			coin_clone.AddForce (transform.right * -speed, ForceMode2D.Impulse);
			coin_clone.AddForce (transform.up * (speed * 1.7f), ForceMode2D.Impulse);

			Physics2D.IgnoreCollision(coin_clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(coin_clone.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		}
	}

	int generate_random_int(int min, int max) {
		return Random.Range(min, max);
	}
}
