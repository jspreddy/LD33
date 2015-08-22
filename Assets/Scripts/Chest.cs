using UnityEngine;
using System.Collections;

public class Chest : Object {
	private bool chest_opened;
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
		float lastX = 0f;
		float lastY = 0f;

		int maxY = -2;
		int minY = -8;
		int minX = -1;
		int maxX = 14;

		for (int i = 0; i < num_coins; i++) {
			Vector3 position = transform.position;

			position.x = position.x - generate_random_int(minX, maxX);
			if (position.x == lastX || position.x == 0) {
				position.x = position.x - generate_random_int(minX, maxX);
			}

			position.y = position.y - generate_random_int(minY, maxY);
			if (position.y == lastY || position.y == 0) {
				position.y = position.y - generate_random_int(-minY, maxY);
			}

			lastX = position.x;
			lastY = position.y;

			Rigidbody2D coin_clone = (Rigidbody2D) Instantiate(coin, position, transform.rotation);
		}
	}

	int generate_random_int(int min, int max) {
		return Random.Range(min, max);
	}
}
