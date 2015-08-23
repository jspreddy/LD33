using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Vector3 mousePosition;

	public float moveSpeed = 10f;
	public bool item_in_hand = false;

	void Start () {
		Cursor.visible = false;

		follow_mouse();
	}


	void Update () {
		follow_mouse();
	}

	public void follow_mouse() {
		mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}
}
