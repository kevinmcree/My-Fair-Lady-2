using UnityEngine;
using System.Collections;

public class Helpful_Mover : MonoBehaviour{
	public GameObject explosion;

	public GameObject shot;
	public float fireRate;
	public float delay;
	public float salvoSize;
	void Start (){
		StartCoroutine (Fire());
	}
	void Update (){
		GameObject Player = GameObject.Find ("Player");
		var position = Player.transform.position;
		position.x += 1.5f;
		transform.position = position;

	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Enemy"){
			Instantiate(explosion, transform.position, transform.rotation);
			GameObject go = GameObject.Find("buySideShooter");
			go.GetComponent<BuySideShooter>().toggle=false;
			Destroy (gameObject);
		}

		
	}
	IEnumerator Fire (){
		while(true){
			GameObject go = GameObject.Find("Game Controller");
			if (go.GetComponent<Done_GameController>().inStore==false){
				for (int i=0; i<salvoSize; i++){
					Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,0));
					audio.Play ();
					yield return new WaitForSeconds (fireRate);
				}
				yield return new WaitForSeconds (delay);
			}
		}

	}

}
