using UnityEngine;
using System.Collections;

public class PickupObject : Object {
	public int max_hp, hp;

	void Start () {
	
	}

	void Update () {
	
	}

	public int get_max_hp() {
		return this.max_hp;
	}

	public void set_hp(int new_hp) {
		this.hp = new_hp;
	}

	public void remove_hp(int amount) {
		this.hp -= amount;
	}

	public int get_hp() {
		return this.hp;
	}

}
