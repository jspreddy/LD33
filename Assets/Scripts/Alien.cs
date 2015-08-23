using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {
	public Player player_script;
	public float speed = 0.01f;
	public GameObject player;

	private Rigidbody2D rb;
	private float ai_loop_speed = 1.0f;
	private string status;
	private bool speed_pos = true;

	private IEnumerator ai_loop() {
		while(true) {
			if (status == "WALK") {
				if (Random.Range(0, 2) == 0) {
					if (speed_pos) {
						speed_pos = false;
					} else {
						speed_pos = true;
					}
				}
			}
			yield return new WaitForSeconds(ai_loop_speed);
		}
	}

	void Start () {
		status = "WALK";
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.right * speed, ForceMode2D.Force);

		player_script = player.GetComponent<Player>();

		StartCoroutine("ai_loop");
	}
	
	void Update () {
		Debug.Log (speed_pos);
		if (player_script.item_in_hand) {
			status = "CHASE";

			if (player.transform.position.x > transform.position.x) {
				rb.AddForce (transform.right * speed, ForceMode2D.Force);
			} else if (player.transform.position.x < transform.position.x) {
				rb.AddForce (transform.right * -speed, ForceMode2D.Force);
			}
		} else {
			status = "WALK";

			if (speed_pos) {
				rb.AddForce (transform.right * -speed, ForceMode2D.Force);
			} else {
				rb.AddForce (transform.right * speed, ForceMode2D.Force);
			}
		}
	}
}
