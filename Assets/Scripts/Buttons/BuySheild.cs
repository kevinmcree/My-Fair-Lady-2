using UnityEngine;
using System.Collections;

public class BuySheild : MonoBehaviour {
	public bool toggle = false;
	public GameObject sheild;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		if (toggle==false && go.GetComponent<Done_GameController>().score>=10000){
			Instantiate (sheild, new Vector3(0,0,0), new Quaternion(0, 0,0,0));
			go.GetComponent<Done_GameController>().AddScore(-5000);
			toggle = true;
			audio.Play ();
		}

	}
}
