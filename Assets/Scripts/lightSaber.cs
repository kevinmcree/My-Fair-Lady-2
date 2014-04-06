using UnityEngine;
using System.Collections;

public class lightSaber : MonoBehaviour {
	public bool extended;
	// Use this for initialization
	void Start () {
		extended = false;

	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("Player");
		if(Input.GetKeyDown("space") && player.GetComponent<Done_PlayerController>().weapon==3 && extended==false){
			audio.Play();
			extended = true;
		}
		if((Input.GetKeyUp("space") && player.GetComponent<Done_PlayerController>().weapon==3) || player.GetComponent<Done_PlayerController>().weapon!=3){
			audio.Stop();
			extended = false;
		}
		if (extended==true){
			if (player.GetComponent<Done_PlayerController>().powerUp==0){
				transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.1f, player.transform.position.z+2.5f);
				transform.localScale = new Vector3(3,1,6);
				this.GetComponent<CapsuleCollider>().height=4;
			}
			if (player.GetComponent<Done_PlayerController>().powerUp==1){
				transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.1f, player.transform.position.z+3.3f);
				transform.localScale = new Vector3(3,1,10);
				this.GetComponent<CapsuleCollider>().height=6;

			}
			if (player.GetComponent<Done_PlayerController>().powerUp==2){
				transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.1f, player.transform.position.z+5.7f);
				transform.localScale = new Vector3(3,1,18);
				this.GetComponent<CapsuleCollider>().height=11;

			}
			if (player.GetComponent<Done_PlayerController>().powerUp==3){
				transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.1f, player.transform.position.z+7.5f);
				transform.localScale = new Vector3(3,1,25);
				this.GetComponent<CapsuleCollider>().height=16;

			}
			if (player.GetComponent<Done_PlayerController>().powerUp==4){
				transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.1f, player.transform.position.z+9.8f);
				transform.localScale = new Vector3(3,1,32);
				this.GetComponent<CapsuleCollider>().height=20;

			}
		}else{
			transform.position = new Vector3(100,100,100);

		}


	
	}

}
