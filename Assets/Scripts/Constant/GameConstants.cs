using UnityEngine;
using System.Collections;

public class GameConstants {

	public enum ItemType {
		knife,
		bag,
		chocolate,
	};

	private static string SPRITES_FOLDER = "Sprites/";

	public static string knifeName =  "Knife";
	public static string bagName =  "Bag";
	public static string chocolateName =  "Chocolate";

	public static Sprite knifeSprite =  null;
	public static Sprite bagSprite =  null;
	public static Sprite chocolateSprite =  null;

	private static int knifeValue 		= 5;
	private static int bagValue 		= 2000;
	private static int chocolateValue 	= 10;

	private static int knifeHp 		= 10;
	private static int bagHp 		= 10;
	private static int chocolateHp 	= 1;

	public static string getName(ItemType type){
		switch(type){
		case ItemType.knife: return knifeName;
		case ItemType.bag: return bagName;
		case ItemType.chocolate: return chocolateName;
		default: return "";
		}
	}

	public static int getValue(ItemType type){
		switch(type){
		case ItemType.knife: return knifeValue;
		case ItemType.bag: return bagValue;
		case ItemType.chocolate: return chocolateValue;
		default: return 0;
		}
	}

	public static int getHp(ItemType type){
		switch(type){
		case ItemType.knife: return knifeHp;
		case ItemType.bag: return bagHp;
		case ItemType.chocolate: return chocolateHp;
		default: return 0;
		}
	}

	public static Sprite getSprite(ItemType type){
		switch(type){
		case ItemType.bag: return getSprite ("bag");
		case ItemType.chocolate: return getSprite ("chocolate");
		case ItemType.knife:
		default: return getSprite("knife");
		}
	}

	private static Sprite getSprite(string spriteName){
		return Resources.Load (SPRITES_FOLDER + spriteName, typeof(Sprite)) as Sprite;
	}

}
