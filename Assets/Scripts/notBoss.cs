using UnityEngine;
using System.Collections;

public class notBoss : MonoBehaviour {
	GameObject go;
	// Use this for initialization
	void Start () {
		go = GameObject.Find("Game Controller");

	}
	
	// Update is called once per frame
	void Update () {
		if (go.GetComponent<Done_GameController> ().isBoss == true){
			Destroy (gameObject);
		}
	
	}
}
