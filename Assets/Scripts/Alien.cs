using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {
	public Player player_script;
	public float speed = 0.01f;
	public GameObject player;
	public int hp, max_hp;

	private Rigidbody2D rb;
	private GameObject current_bag;
	private Bag bag;
	private float ai_loop_speed = 1.7f;
	private string status;
	private bool speed_pos = true;
	private bool can_attack = true;
	private int damage = 50;
	private int stand_cycles = 0;
	private int stand_max_cycles = 3;
	private int attack_cycles = 0;
	private int attack_max_cycles = 1;

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
			} else if (status == "STAND") {
				if (stand_cycles < stand_max_cycles) {
					stand_cycles++;
				} else {
					status = "WALK";
					stand_cycles = 0;
				}
			}

			// Attack cycle
			// TODO:: add random break chance
			if (!can_attack) {
				if (attack_cycles < attack_max_cycles) {
					attack_cycles++;
				} else {
					can_attack = true;
					attack_cycles = 0;
				}
			}

			yield return new WaitForSeconds(ai_loop_speed);
		}
	}

	void Start () {
		status = "WALK";
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.right * speed, ForceMode2D.Force);

		max_hp = 20;
		hp = max_hp;

		player_script = player.GetComponent<Player>();

		StartCoroutine("ai_loop");
	}
	
	void Update () {
		if (player_script.item_in_hand) {
			status = "CHASE";

			if (player.transform.position.x > transform.position.x) {
				rb.AddForce (transform.right * speed, ForceMode2D.Force);
			} else if (player.transform.position.x < transform.position.x) {
				rb.AddForce (transform.right * -speed, ForceMode2D.Force);
			}
		} else if (status == "STAND") {
			// Stay still
		} else if (status == "ATTACK_BAG") {
			if (can_attack) {
				if (GameObject.FindWithTag("bag")) {
					current_bag = GameObject.FindWithTag("bag");
					bag = current_bag.GetComponent<Bag>();
					bag.remove_hp(damage);
					can_attack = false;
				}
			}
		} else {
			status = "WALK";

			if (speed_pos) {
				rb.AddForce (transform.right * -speed, ForceMode2D.Force);
			} else {
				rb.AddForce (transform.right * speed, ForceMode2D.Force);
			}
		}

		// Check for death
		if (this.hp <= 0) {
			Object.Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "chest") {
			status = "STAND";
		} else if (col.gameObject.tag == "bag") {
			status = "ATTACK_BAG";
		} else if (col.gameObject.tag == "knife") {
			GameObject knife = GameObject.FindWithTag("knife");
			if (knife == player_script.item_held) {
				Weapon wep_script = knife.GetComponent<Weapon>();
				hp -= wep_script.damage;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "bag") {
			status = "WALK";
		}
	}
}
