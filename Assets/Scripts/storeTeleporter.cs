using UnityEngine;
using System.Collections;

public class storeTeleporter : MonoBehaviour {
	public GameObject explosion;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{	
		if (other.tag == "Boundary" || other.tag == "Enemy"){
			return;
		}
		if (other.tag == "Player"  ){
			GameObject go = GameObject.Find("Game Controller");
			GameObject yo = GameObject.Find("Player");
			yo.GetComponent<Done_PlayerController>().onScreen=false;

			if (yo.GetComponent<Done_PlayerController>().shipType!=4){
				go.GetComponent<Done_GameController>().inStore=true;
				go.GetComponent<Done_GameController>().audio.Pause();

				GameObject store = GameObject.Find("Store");
				store.audio.Play ();

			//	GameObject comboText = GameObject.Find("Combo");
			//	comboText.transform.position = new Vector3 (10,10,10);

				Camera.main.transform.position = new Vector3(-80, 20.4f, -30);
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
