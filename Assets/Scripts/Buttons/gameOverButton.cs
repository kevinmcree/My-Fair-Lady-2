using UnityEngine;
using System.Collections;

public class gameOverButton : MonoBehaviour {
	public int choice;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		if (choice==0){
			Application.LoadLevel ("options select");
		}
		else{
			Application.LoadLevel ("Main Game");
		}
	}

}
