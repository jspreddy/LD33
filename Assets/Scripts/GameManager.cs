using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	int kills = 0;
	int gold = 5000;
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





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
