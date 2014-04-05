using UnityEngine;
using System.Collections;
public class sheild{
	
	public int sheildHealth;
	
	void start(){
		sheildHealth = 5;
	}
	
	void update(){
		GameObject Player = GameObject.Find ("Player");
		//rigidbody.position = new Vector3(Player.rigidbody.position.x, Player.rigidbody.position.y, Player.rigidbody.position.z);
		if (sheildHealth <= 0)
			return;
	}
	
	void OnTriggerEnter (Collider other){
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
}

