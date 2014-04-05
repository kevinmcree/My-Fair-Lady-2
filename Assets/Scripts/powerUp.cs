using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {
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
		if (other.tag == "Player"){
			GameObject go = GameObject.Find("Player");
			go.GetComponent<Done_PlayerController>().powerUp++;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		
		
	}
}