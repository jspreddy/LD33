using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject sceneCamera;
	public GameObject inventory;
	public bool testShop = false;

	private int kills = 0;
	private int gold = 100;
	private GameObject shop;
	private float timeTillShopShow = 0;


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
		if(testShop){
			checkAndShowShopIfApplicable();
		}
	}

	private void checkAndShowShopIfApplicable(){
		timeTillShopShow += Time.deltaTime;
		if(timeTillShopShow > 4.0f){
			testShop = false;
			shop = Instantiate(Resources.Load ("Prefabs/Shop/Shop", typeof(GameObject))) as GameObject;
			sceneCamera.SetActive(false);
			setInventoryViewOnly(true);
		}
	}

	public void refreshShopTimer(){
		this.timeTillShopShow = 0.0f;
		this.testShop = true;
		GameObject.Destroy (shop);
		sceneCamera.SetActive(true);
		setInventoryViewOnly (false);
	}


	public void setInventoryViewOnly(bool viewOnly){
		inventory.GetComponent<InventoryManager> ().setViewOnly (viewOnly);
	}

}
