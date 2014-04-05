using UnityEngine;
using System.Collections;

public class buyScoreMult : MonoBehaviour {
	public int cost;

	// Use this for initialization
	void Start () {
		GameObject words = GameObject.Find("ScoreCost");
		words.GetComponent<TextMesh>().text = "Score x2 Multiplier: " +cost;

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().score>=cost){
			go.GetComponent<Done_GameController>().scoreMultiplier = go.GetComponent<Done_GameController>().scoreMultiplier*2;
			go.GetComponent<Done_GameController>().AddScore(-(cost/go.GetComponent<Done_GameController>().scoreMultiplier));
			audio.Play ();
			GameObject words = GameObject.Find("ScoreCost");
			words.GetComponent<TextMesh>().text = "Score x2 Multiplier: " +cost;
			cost=cost*5;

			
		}
	}
}

