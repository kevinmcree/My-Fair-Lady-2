using UnityEngine;
using System.Collections;
using System;


public class littleDoctor : MonoBehaviour {
	public GameObject explosion;
	public GameObject shot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other){
		if (String.Compare(other.tag,"Enemy")==0){
			Debug.Log("wassup?");

			GameObject go = GameObject.Find("Player");

			if ((String.Compare(go.GetComponent<Done_PlayerController>().playerColor, other.GetComponent<Done_DestroyByContact>().color)==0) || (String.Compare("none", other.GetComponent<Done_DestroyByContact>().color) == 0)){
				other.GetComponent<Done_DestroyByContact>().hits--;				
				if(other.GetComponent<Done_DestroyByContact>().hits<=0){
					Destroy (other.gameObject);
	
				Instantiate(explosion, transform.position, transform.rotation);
				GameObject yo = GameObject.Find("Game Controller");
				yo.GetComponent<Done_GameController>().AddCombo();
				yo.GetComponent<Done_GameController>().AddScore(other.GetComponent<Done_DestroyByContact>().scoreValue*yo.GetComponent<Done_GameController>().combo);
			
			if (go.GetComponent<Done_PlayerController>().powerUp==0){
					Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 360,0,90));
					Destroy (gameObject);
			}
			if (go.GetComponent<Done_PlayerController>().powerUp==1){
					Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 360,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -60,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 60,0,90));
					Destroy (gameObject);
			}			
			if (go.GetComponent<Done_PlayerController>().powerUp==2){
					Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 60,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 300,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 360,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -60,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -300,0,90));
					Destroy (gameObject);
			}	
			if (go.GetComponent<Done_PlayerController>().powerUp==3){
					Instantiate(shot, this.transform.position, new Quaternion(0, 0,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 30,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 60,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 90,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 150,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 210,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 270,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 300,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 330,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, 360,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -30,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -60,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -90,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -120,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -150,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -180,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -210,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -240,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -270,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -300,0,90));
					Instantiate(shot, this.transform.position, new Quaternion(0, -3,0,90));
					Destroy (gameObject);
			}			

			if (go.GetComponent<Done_PlayerController>().powerUp==4){
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
				Destroy (gameObject);
				}
			}
			}
		}
	}
}


