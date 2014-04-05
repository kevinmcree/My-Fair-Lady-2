using UnityEngine;
using System.Collections;

public class buyCannon : MonoBehaviour {
	public bool toggle;
	// Use this for initialization
	void Start () {
		toggle = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		if (toggle==false && go.GetComponent<Done_GameController>().score>=8000){
			GameObject yo = GameObject.Find("Player");
			yo.GetComponent<Done_PlayerController>().weapon=1;
			go.GetComponent<Done_GameController>().AddScore(-8000/go.GetComponent<Done_GameController>().scoreMultiplier);
			toggle = true;
			audio.Play ();
		}
	}
}
