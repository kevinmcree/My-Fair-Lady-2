using UnityEngine;
using System.Collections;

public class LeaveStore : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		go.GetComponent<Done_GameController>().inStore=false;
		go.GetComponent<Done_GameController>().audio.Play();

		GameObject store = GameObject.Find("Store");
		store.audio.Stop ();

		//GameObject comboText = GameObject.Find("Combo");
		//comboText.transform.position = new Vector3 (77.5f,-4.5f,31);

		Camera.main.transform.position = new Vector3(0, 22.7f, 4.3f);
		audio.Play(); 
	}
}
