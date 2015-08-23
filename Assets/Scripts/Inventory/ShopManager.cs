using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Transform topBarTransform;
	public Transform topBarGoldTextTransform;

	private List<BuyItem> buyItems = new List<BuyItem>();

	private GameManager gameManager;
	private InventoryManager inventoryManager;



	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
		inventoryManager = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<InventoryManager> ();
		setGoldUiDisplay (gameManager.getGold());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addBuyItem(Item.Type type){
		for(int i =0; i< buyItems.Count; i++){
			if(buyItems[i].type == type){
				buyItems[i].incrementCount();
				return;
			}
		}
		buyItems.Add (new BuyItem (type, 1));
	}

	public void clearBuyItems(){
		buyItems.Clear ();
		Debug.Log("Clear Buy List.");
	}

	private int getCheckoutCost(){
		int cost = 0;
		for(int i = 0; i < buyItems.Count; i++){
			cost += buyItems[i].getCost();
		}
		return cost;
	}

	public void buy(){
		int cost = this.getCheckoutCost ();
		int currentGold = gameManager.getGold ();
		Debug.Log ("Gold: "+ currentGold + ",    cost: "+cost);
		if(cost < currentGold){
			setGoldUiDisplay(gameManager.spendGold(cost));
			inventoryManager.addItems(buyItems);
			clearBuyItems();
		}
		else{
			// TODO: create alert message system.
			// TODO: shake main gold display.
			this.topBarTransform.GetComponent<UiShaker>().shake();
			Debug.Log ("Not Enough Gold.");
		}
	}


	private void setGoldUiDisplay(int gold){
		topBarGoldTextTransform.GetComponent<Text> ().text = gold.ToString("C");
	}
}
