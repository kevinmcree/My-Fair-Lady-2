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
			go.GetComponent<Done_PlayerController>().playerHealth++;
			GameObject health = GameObject.Find("Health");
			health.transform.position += new Vector3(0,0,.5f);
			health.transform.localScale -= new Vector3 (-1f,0,0); 
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}


}
}
