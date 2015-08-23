﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Transform topBarTransform;
	public Transform topBarGoldTextTransform;
	public Transform topBarGoldCostTransform;

	public Transform buyListContainer;

	public GameObject buyRowPrefab;


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
			if(buyItems[i].getType () == type){
				buyItems[i].incrementCount();
				renderItemList ();
				return;
			}
		}
		buyItems.Add (new BuyItem (type, 1));
		renderItemList ();
	}

	public void clearBuyItems(){
		buyItems.Clear ();
		renderItemList ();
		Debug.Log("Clear Buy List.");
	}

	public void buy(){
		int cost = this.getCheckoutCost ();
		int currentGold = gameManager.getGold ();
		Debug.Log ("Gold: "+ currentGold + ",    cost: "+cost);
		if(cost <= currentGold){
			setGoldUiDisplay(gameManager.spendGold(cost));
			inventoryManager.addItems(buyItems);
			clearBuyItems();
			renderItemList ();
		}
		else{
			// TODO: create alert message system.
			this.topBarTransform.GetComponent<UiShaker>().shake();
			Debug.Log ("Not Enough Gold.");
		}
	}
	public void continueToNextScene(){
		gameManager.refreshShopTimer ();
	}

	private int getCheckoutCost(){
		int cost = 0;
		for(int i = 0; i < buyItems.Count; i++){
			cost += buyItems[i].getCost();
		}
		return cost;
	}

	private void renderItemList(){
		foreach (Transform child in buyListContainer) {
			GameObject.Destroy(child.gameObject);
		}

		foreach(BuyItem buyItem in buyItems){
			GameObject buyRow = Instantiate (buyRowPrefab);
			buyRow.GetComponent<BuyRow> ().setData (Item.getName (buyItem.getType()), buyItem.getCount(), buyItem.getCost());
			buyRow.transform.SetParent(buyListContainer, false);
		}

		setGoldCost (getCheckoutCost ());
	}

	private void setGoldUiDisplay(int gold){
		topBarGoldTextTransform.GetComponent<Text> ().text = gold.ToString("C");
	}

	private void setGoldCost(int goldCost){
		topBarGoldCostTransform.GetComponent<Text> ().text = "- " + goldCost.ToString ("C");
	}
}
