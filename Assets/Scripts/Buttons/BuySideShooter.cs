using UnityEngine;
using System.Collections;

public class BuySideShooter : MonoBehaviour {
	public bool toggle = false;
	public GameObject sideShooter;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){

		GameObject go = GameObject.Find("Game Controller");
		if (toggle==false && go.GetComponent<Done_GameController>().score>=2000){
			Instantiate (sideShooter, new Vector3(0,0,0), new Quaternion(0, 0,0,0));
			go.GetComponent<Done_GameController>().AddScore(-(2000/go.GetComponent<Done_GameController>().scoreMultiplier));
			toggle = true;
			audio.Play ();
		}
		
	}
}