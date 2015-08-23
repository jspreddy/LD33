using UnityEngine;
using System.Collections;

public class BuyItem {

	private Item.ItemType type;
	private int count;

	public BuyItem(Item.ItemType type, int count){
		this.type = type;
		if (count > 0){
			this.count = count;
		}
		else {
			this.count = 0;
		}
	}

	public Item.ItemType getType(){
		return this.type;
	}
	public int getCount(){
		return this.count;
	}
	public int getCost(){
		return count * Item.getValue (type);
	}


	public void incrementCount(){
		this.count++;
	}

}
