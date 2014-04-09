using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
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
			if (go.GetComponent<Done_PlayerController>().playerHealth<go.GetComponent<Done_PlayerController>().maxHealth){
				go.GetComponent<Done_PlayerController>().playerHealth++;
				GameObject health = GameObject.Find("Health");
				float temp = 4/go.GetComponent<Done_PlayerController>().maxHealth;
				health.transform.position += new Vector3(0,0,temp);			
			}
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}


}
}
