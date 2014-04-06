using UnityEngine;
using System.Collections;

public class shieldPickUp : MonoBehaviour {
	public GameObject explosion;
	public GameObject sheild;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{	
				if (other.tag == "Boundary" || other.tag == "Enemy") {
						return;
				}
				if (other.tag == "Player") {
						GameObject go = GameObject.Find ("Player");
						if (go.GetComponent<Done_PlayerController> ().hasShield == false) {
								Instantiate (sheild, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
						} else {
								GameObject yo = GameObject.Find ("player_sheild(Clone)");
								yo.GetComponent<sheild> ().sheildHealth++;
						}
						if (explosion != null) {
								Instantiate (explosion, transform.position, transform.rotation);
						}
						Destroy (gameObject);
				}
		}
		
		
	}