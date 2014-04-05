using UnityEngine;
using System.Collections;

public class buyCannon : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		GameObject yo = GameObject.Find("Player");
		if (yo.GetComponent<Done_PlayerController>().weapon!=1 && go.GetComponent<Done_GameController>().score>=8000){
			yo.GetComponent<Done_PlayerController>().weapon=1;
			go.GetComponent<Done_GameController>().AddScore(-8000/go.GetComponent<Done_GameController>().scoreMultiplier);
			audio.Play ();
		}
	}
}
