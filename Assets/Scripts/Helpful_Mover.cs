using UnityEngine;
using System.Collections;

public class Helpful_Mover : MonoBehaviour{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	void Start (){
		InvokeRepeating ("Fire", delay, fireRate);
	}
	void Update (){
		GameObject Player = GameObject.Find ("Player");
		var position = Player.transform.position;
		position.x += 3;
		transform.position = position;

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Enemy_Shot_Yellow") {
			Destroy(gameObject);
		}
		if (col.gameObject.name == "Enemy_Shot_Red" ) {
			Destroy(gameObject);
		}
		if (col.gameObject.name == "Enemy_Shot_Blue") {
			Destroy(gameObject);
		}
		
	}
	void Fire (){
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		audio.Play();
	}

}
