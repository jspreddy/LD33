using UnityEngine;
using System.Collections;

public class Item {

	private GameConstants.ItemType type;
	private int count;

	public Item(GameConstants.ItemType type, int count){
		this.type = type;
		if (count > 0){
			this.count = count;
		}
		else {
			this.count = 0;
		}
	}

	public GameConstants.ItemType getType(){
		return this.type;
	}
	public int getCount(){
		return this.count;
	}
	public int getCost(){
		return count * GameConstants.getValue (type);
	}


	public void incrementCount(){
		this.count++;
	}

}
