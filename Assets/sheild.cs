using UnityEngine;
using System.Collections;
public class sheild : MonoBehaviour{
	
	public int sheildHealth;
	
	void start(){
		sheildHealth = 5;
	}
	
	void update(){
		GameObject Player = GameObject.Find ("Player");
		//Done_PlayerController playerController = Player.GetComponent<Done_PlayerController> ();
		//Transform.position = new Vector3(Player.rigidbody.position.x, Player.rigidbody.position.y, Player.rigidbody.position.z);
		transform.position = Player.transform.position;
		if (sheildHealth <= 0)
			Destroy (gameObject);
	}
	
/*	void OnTriggerEnter (Collider other){
		GameObject Player = GameObject.Find ("Player");
		Done_PlayerController playerController = Player.GetComponent<Done_PlayerController> ();
		string playerColor = playerController.playerColor;
		if (other.tag == "Enemy_Shot_Yellow" &&  playerColor == "yellow") {
			sheildHealth -= 1;
		}
		if (other.tag == "Enemy_Shot_Red" &&  playerColor == "red") {
			sheildHealth -= 1;
		}
		if (other.tag == "Enemy_Shot_Blue" &&  playerColor == "blue") {
			sheildHealth -= 1;
		}
		
	}
	*/
	void OnCollisionEnter(Collision col){
		GameObject Player = GameObject.Find ("Player");
		Done_PlayerController playerController = Player.GetComponent<Done_PlayerController> ();
		string playerColor = playerController.playerColor;
		if (col.gameObject.name == "Enemy_Shot_Yellow" &&  playerColor == "yellow") {
			sheildHealth -= 1;
		}
		if (col.gameObject.name == "Enemy_Shot_Red" &&  playerColor == "red") {
			sheildHealth -= 1;
		}
		if (col.gameObject.name == "Enemy_Shot_Blue" &&  playerColor == "blue") {
			sheildHealth -= 1;
		}

	}
}

