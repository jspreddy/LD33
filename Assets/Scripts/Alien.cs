using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public float jumpSpeed;
	
	private Vector3 mousePosition;
	private Vector3 moveDirection;

	void Start () {
	}
	
	void Update () {

		CharacterController controller = GetComponent<CharacterController>();

		float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

		if (transform.position.x < (mouseX + .5)) 
		{
			moveDirection = new Vector3(1,0,0);
			controller.SimpleMove(moveDirection * speed);

		}
		else if(transform.position.x > (mouseX - .5))
		{
			moveDirection = new Vector3(-1,0,0);
			controller.SimpleMove(moveDirection * speed);
		}

	}
}
