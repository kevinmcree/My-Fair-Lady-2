using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
	public GameObject explosion;
	public bool toggle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (toggle == true){
			GameObject health = GameObject.Find("Health");
			if (this.transform.position.y<health.transform.position.y){
				this.transform.position += new Vector3 (0, .5f,0);
			}
			transform.position = Vector3.MoveTowards(transform.position, health.transform.position, .5f);

		}	
	}

void OnTriggerEnter (Collider other)
{	
	if (other.tag == "Boundary" || other.tag == "Enemy"){
		return;
	}
	if (other.tag == "Player"){
			rigidbody.velocity = new Vector3 (0,0,0);
			toggle = true;
			audio.Play ();
	}
	if (other.tag == "healthBar"){
		GameObject go = GameObject.Find("Player");
		if (go.GetComponent<Done_PlayerController>().playerHealth<go.GetComponent<Done_PlayerController>().maxHealth){
			go.GetComponent<Done_PlayerController>().playerHealth++;
			GameObject health = GameObject.Find("Health");
			float temp = 4.0f/go.GetComponent<Done_PlayerController>().maxHealth;
			health.transform.position += new Vector3(0,0,temp);	
		}

		if (explosion != null){
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}


}
}
