using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	int kills = 0;
	int gold = 100;
	GameObject shop;
	public void addGold(int g){
		this.gold += g;
	}
	public int getGold(){
		return this.gold;
	}
	public int spendGold(int g){
		return this.gold -= g;
	}
	public void incrementKill(){
		this.kills++;
	}


	float time = 0;
	bool start = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(start){
			time += Time.deltaTime;
			if(time > 4.0f){
				start = false;
				shop = Instantiate(Resources.Load ("Prefabs/Shop/Shop", typeof(GameObject))) as GameObject;

			}
		}
	}

	public void refreshShopTimer(){
		this.time = 0.0f;
		this.start = true;
		GameObject.Destroy (shop);
	}


}
