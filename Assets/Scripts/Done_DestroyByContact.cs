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
	public int hits;
	public GameObject shot;




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
				GameObject go = GameObject.Find("player_sheild");
				go.GetComponent<sheild>().sheildHealth--;
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
				if (go.GetComponent<sheild>().sheildHealth<=0){
					Destroy (other.gameObject);
					Destroy (gameObject);
					GameObject jo = GameObject.Find("buySheild");
					jo.GetComponent<BuySheild>().toggle=false;
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
				Destroy (other.gameObject);
				hits--;				
				if(hits<=0){
					Instantiate(explosion, transform.position, transform.rotation);
					gameController.AddCombo();
					gameController.AddScore(scoreValue*gameController.combo);
					if (go.GetComponent<Done_PlayerController>().weapon == 2){
						Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 20,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 40,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 60,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 80,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 100,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 120,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 140,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 160,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 180,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 200,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 220,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 240,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 260,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 280,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 300,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 320,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 340,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, 360,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -20,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -40,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -60,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -80,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -100,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -120,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -140,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -160,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -180,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -200,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -220,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -240,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -260,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -280,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -300,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -320,0,90));
						Instantiate(shot, this.transform.position, new Quaternion(0, -340,0,90));
					}
					Destroy (gameObject);
				}else{
					return;
				}
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