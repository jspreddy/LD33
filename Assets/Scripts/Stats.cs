using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	public static int coins_collected;
	public int coins_dropped;
	public int aliens_killed;
	public int aliens_let_go;

	void Start () {
		coins_collected = 0;
		coins_dropped = 0;
		aliens_killed = 0;
		aliens_let_go = 0;
	}
}
