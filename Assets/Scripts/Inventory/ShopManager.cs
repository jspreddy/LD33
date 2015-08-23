using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Transform topBarTransform;
	public Transform topBarGoldTextTransform;
	public Transform topBarGoldCostTransform;

	public Transform buyListContainer;

	public GameObject buyRowPrefab;


	private List<Item> cartItems = new List<Item>();

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

	public void addItemToCart(GameConstants.ItemType type){
		for(int i =0; i< cartItems.Count; i++){
			if(cartItems[i].getType () == type){
				cartItems[i].incrementCount();
				renderCartItemList ();
				return;
			}
		}
		cartItems.Add (new Item (type, 1));
		renderCartItemList ();
	}

	public void clearCartItems(){
		cartItems.Clear ();
		renderCartItemList ();
		Debug.Log("Clear Buy List.");
	}

	public void buy(){
		int cost = this.getCheckoutCost ();
		int currentGold = gameManager.getGold ();
		Debug.Log ("Gold: "+ currentGold + ",    cost: "+cost);
		if(cost <= currentGold){
			setGoldUiDisplay(gameManager.spendGold(cost));
			inventoryManager.addItems(cartItems);
			clearCartItems();
			renderCartItemList ();
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
		for(int i = 0; i < cartItems.Count; i++){
			cost += cartItems[i].getCost();
		}
		return cost;
	}

	private void renderCartItemList(){
		foreach (Transform child in buyListContainer) {
			GameObject.Destroy(child.gameObject);
		}

		foreach(Item buyItem in cartItems){
			GameObject buyRow = Instantiate (buyRowPrefab);
			buyRow.GetComponent<ShopCartRow> ().setData (GameConstants.getName (buyItem.getType()), buyItem.getCount(), buyItem.getCost());
			buyRow.transform.SetParent(buyListContainer, false);
		}

		setGoldCostDisplay (getCheckoutCost ());
	}

	private void setGoldUiDisplay(int gold){
		topBarGoldTextTransform.GetComponent<Text> ().text = gold.ToString("C");
	}

	private void setGoldCostDisplay(int goldCost){
		topBarGoldCostTransform.GetComponent<Text> ().text = "- " + goldCost.ToString ("C");
	}
}
