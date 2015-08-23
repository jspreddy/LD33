using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

	public Item.ItemType type;

	private ShopManager shopManager;

	// Use this for initialization
	void Start () {
		Image img = this.transform.GetChild(0).GetComponent<Image> ();
		img.sprite = Item.getSprite (type);

		shopManager = GameObject.FindGameObjectWithTag ("Shop").GetComponent<ShopManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void onInventoryItemClick(){
		shopManager.addBuyItem (type);
	}

}
