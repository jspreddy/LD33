using UnityEngine;
using System.Collections;

public class PickupObject : Object {
	public int max_hp, hp;

	void Start () {
	
	}

	void Update () {
	
	}

	int get_max_hp() {
		return this.max_hp;
	}

	void set_hp(int new_hp) {
		this.hp = new_hp;
	}

	int get_hp() {
		return this.hp;
	}

}
