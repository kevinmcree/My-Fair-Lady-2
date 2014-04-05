using UnityEngine;
using System.Collections;
using System;


public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	public string color;



	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}
	void Update ()
	{
		if (transform.position.z<=-8)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "UI")
		{
			return;
		}
		if (other.tag=="barrier"){
			GameObject yo = GameObject.Find("Player");
			if ((String.Compare(yo.GetComponent<Done_PlayerController>().playerColor, color)==0) || (String.Compare("none", color) == 0)){
				GameObject sheild = GameObject.Find("player_sheild");
				sheild.GetComponent<sheild>().sheildHealth--;
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
				if (sheild.GetComponent<sheild>().sheildHealth<=0){
					Destroy (other.gameObject);
					Destroy (gameObject);
					GameObject go = GameObject.Find("buySheild");
					go.GetComponent<BuySheild>().toggle=false;
					Instantiate(explosion, transform.position, transform.rotation);
				}
			}
				return;
		}

			if (other.tag == "Player"){
			GameObject go = GameObject.Find("Player");
		if ((String.Compare(go.GetComponent<Done_PlayerController>().playerColor, color)==0) || (String.Compare("none", color) == 0)){
				go.GetComponent<Done_PlayerController>().playerHealth--;
				go.GetComponent<Done_PlayerController>().powerUp=0;
				GameObject health = GameObject.Find("Health");
				health.transform.position -= new Vector3(0,0,.5f);
				health.transform.localScale += new Vector3 (-1,0,0); 
				if(go.GetComponent<Done_PlayerController>().playerHealth<=0){
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver();
				}else{
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					Instantiate(explosion, transform.position, transform.rotation);
					Destroy (gameObject);
					return;
				}
			} else {
				return;
			}
 		}

		if (other.tag == "projectile"){
			GameObject go = GameObject.Find("Player");
			if ((String.Compare(go.GetComponent<Done_PlayerController>().playerColor, color)==0) || (String.Compare("none", color) == 0)){
				Instantiate(explosion, transform.position, transform.rotation);
				gameController.AddCombo();
				gameController.AddScore(scoreValue*gameController.combo);
				Destroy (other.gameObject);
				Destroy (gameObject);
			} else {
				return;
			}
		}
		//if (other.tag == "edge"){
		//	Destroy (gameObject);
		//	return;
		//}


			if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}