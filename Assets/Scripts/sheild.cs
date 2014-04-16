using UnityEngine;
using System.Collections;
public class sheild : MonoBehaviour {
	
	public int sheildHealth;
	
	void Start(){
		sheildHealth = 1;
	}
	
	void Update(){
		GameObject go = GameObject.Find("buySheild");
		go.GetComponent<BuySheild>().toggle=true;

		GameObject player = GameObject.Find ("Player");
		transform.position = new Vector3(player.transform.position.x-1.2f, player.transform.position.y-1, player.transform.position.z);
	}
	
//	void OnTriggerEnter (Collider other){
//		if (other.tag == "Enemy"){
//			GameObject Player = GameObject.Find ("Player");
//			Done_PlayerController playerController = Player.GetComponent<Done_PlayerController> ();

//			string playerColor = playerController.playerColor;
//			sheildHealth -= 1;
//		}

//	}
}

