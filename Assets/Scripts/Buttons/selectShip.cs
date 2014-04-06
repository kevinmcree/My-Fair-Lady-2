using UnityEngine;
using System.Collections;

public class selectShip : MonoBehaviour {
	public int ship;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		GameObject opt = GameObject.Find("options");
		opt.GetComponent<options> ().shipType = ship;
	}
	
}