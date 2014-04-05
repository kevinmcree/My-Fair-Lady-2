using UnityEngine;
using System.Collections;

public class buyGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		GameObject yo = GameObject.Find("Player");
		if (go.GetComponent<Done_GameController>().score>=3000 && yo.GetComponent<Done_PlayerController>().powerUp<=3){
			go.GetComponent<Done_GameController>().AddScore(-(3000/go.GetComponent<Done_GameController>().scoreMultiplier));
			yo.GetComponent<Done_PlayerController>().powerUp++;
			audio.Play ();
		}
		
	}

}
