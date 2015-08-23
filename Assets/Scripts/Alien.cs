using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	public float jumpHeight;
	
	private Vector3 mousePosition;
	private Vector3 moveDirection;
	private float rbVelocity;
	private bool isJumping;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		isJumping = false;
	}
	
	void FixedUpdate () {
		
		float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		
		if (transform.position.x < (mouseX + .5)) 
		{
			transform.position += transform.right * speed * Time.deltaTime;
			
		}
		else if(transform.position.x > (mouseX - .5))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
	}

	void Jump() {

		rbVelocity = rb.velocity.y;

		float mouseY = Input.mousePosition.y;
		
		Debug.Log (mouseY);
		
		if (rbVelocity == 0 ) {
			
			rb.AddForce(Vector2.up * ((mouseY * 11) / 5));
		}

	}
	
	void OnCollisionStay2D(Collision2D coll) {
		
		if (Input.GetKey(KeyCode.W)) {

			Jump ();
		}
	}
}
