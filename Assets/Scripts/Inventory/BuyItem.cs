using UnityEngine;
using System.Collections;

public class BuyItem {

	public Item.Type type;
	public int count;

	public BuyItem(Item.Type type, int count){
		this.type = type;
		if (count > 0){
			this.count = count;
		}
		else {
			this.count = 0;
		}
	}

	public int getCost(){
		return count * Item.getValue (type);
	}

	public void incrementCount(){
		this.count++;
	}

}
