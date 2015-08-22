using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
	private Vector3 mousePosition;
	
	public float moveSpeed = 10f;
	public int price;
	public bool in_hand = false;

	public GameObject player;

	void Start () {
	
	}

	void Update () {
	
	}

	public void follow_mouse() {
		player.active = false;

		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}
}
