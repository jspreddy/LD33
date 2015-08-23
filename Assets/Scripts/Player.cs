using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Vector3 mousePosition;

	public float moveSpeed = 10f;
	public bool item_in_hand = false;

	public GameObject item_held;

	void Start () {
		Cursor.visible = false;

		follow_mouse();
	}


	void Update () {
		// Check end of game
		if (Stats.coins_left == 0) {
			Application.LoadLevel(0);
		}

		follow_mouse();
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Do stuff
	}

	public void follow_mouse() {
		mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}
}
