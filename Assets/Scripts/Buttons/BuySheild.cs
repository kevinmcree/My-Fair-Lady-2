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
		if (toggle==false){
			Instantiate (sheild, new Vector3(0,0,0), new Quaternion(0, 0,0,0));
			GameObject go = GameObject.Find("Game Controller");
			go.GetComponent<Done_GameController>().AddScore(-10000);
		}

		toggle = true;
	}
}
