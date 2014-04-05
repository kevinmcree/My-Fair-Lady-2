using UnityEngine;
using System.Collections;

public class buyBonusMult : MonoBehaviour {
	public int cost;
	
	// Use this for initialization
	void Start () {
		GameObject words = GameObject.Find("BonusCost");
		words.GetComponent<TextMesh>().text = "Combo last longer: " +cost;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().score>=cost){
			go.GetComponent<Done_GameController>().comboExtender +=50;
			go.GetComponent<Done_GameController>().AddScore(-(cost/go.GetComponent<Done_GameController>().scoreMultiplier));
			cost=cost*5;
			audio.Play ();
			GameObject words = GameObject.Find("BonusCost");
			words.GetComponent<TextMesh>().text = "Combo last longer: " +cost;
			
		}
	}
}