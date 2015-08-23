using UnityEngine;
using System.Collections;

public class UiShaker : MonoBehaviour {

	private bool bShake = false;
	public float amount = 3f;
	public float time = 1f;
	public float shakienessMultiplier = 20;

	public Vector3 originalPosition;

	private float updateTime = 0.0f;
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(bShake){
			float ping = Mathf.PingPong (Time.time * shakienessMultiplier, amount);
			Debug.Log (ping);
			this.transform.localPosition = new Vector3(this.transform.localPosition.x - (amount/2) + ping, this.transform.localPosition.y, this.transform.localPosition.z);
			updateTime -= Time.deltaTime;
			if(updateTime < 0){
				bShake = false;
				this.transform.localPosition = originalPosition;
			}
		}
	}

	public void shake(){
		if(amount > 0 && time > 0){
			this.bShake = true;
		}
		updateTime = time;
	}
}
