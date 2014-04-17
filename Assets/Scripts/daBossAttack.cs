using UnityEngine;
using System.Collections;

public class daBossAttack : MonoBehaviour {

	public GameObject redShot;
	public GameObject blueShot;
	public GameObject yellowShot;
	public Transform shotSpawn;
	public Transform shotAngle;

	public int coolDown;
	public int attackCol;
	public int attackType;

	void Start () {
		GameObject yo = GameObject.Find ("Game Controller");

		yo.GetComponent<Done_GameController>().audio.Pause();
		yo.GetComponent<Done_GameController>().bossSource[0].Play();

		coolDown = 0;
	}
	
	//Each frame the boss attack cooldown decrements
	//If the cooldown is <= 0 the boss randomizes an attack type and color
	//then executes the attack in the chosen color
	void Update () {
		this.transform.position = new Vector3 (0, this.transform.position.y, this.transform.position.z);
		if (this.GetComponent<Done_DestroyByContact>().hits<=20){
			GameObject yo = GameObject.Find ("Game Controller");
			yo.GetComponent<Done_GameController>().audio.Play();
			yo.GetComponent<Done_GameController>().boss = false;
			yo.GetComponent<Done_GameController>().isBoss = false;
			yo.GetComponent<Done_GameController>().bossSource[0].Pause();
			yo.GetComponent<Done_GameController>().range--;
			Destroy (gameObject);
		}

		//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		if (coolDown <= 0) {
			attackCol = Random.Range (0, 2);
			attackType = Random.Range (0, 2);

			attackType = 1;

			switch(attackType){
				case 0:
					attack1();
					break;
				case 1:
					attack2 ();
					break;
				case 2:
					attack3 ();
					break;
				default:
					break;
			}
		}
		coolDown--;
	}

	//Line attack, covers the screen with a solid line of bullets
	public void attack1(){
		Vector3 shotPos;
		int colorType = Random.Range (0, 3);
		switch(colorType){
			case 0:
				for (int i = 0; i < 800; i++){
					shotPos = new Vector3(i, 0, 0);
					Instantiate (blueShot, shotSpawn.position + shotPos, shotSpawn.rotation);
				}
				break;
			case 1:
				for (int i = 0; i < 800; i++){
					shotPos = new Vector3(i, 0, 0);
					Instantiate (redShot, shotSpawn.position + shotPos, shotSpawn.rotation);
				}
				break;
			case 2:
				for (int i = 0; i < 800; i++){
					shotPos = new Vector3(i, 0, 0);
					Instantiate (yellowShot, shotSpawn.position + shotPos, shotSpawn.rotation);
				}
				break;
			default: 
				break;
		}
		coolDown = 150;
	}

	//Shoots diagonal shots
	public void attack2(){
		Vector3 shotPos;
		int colorType = Random.Range (0, 3);
		switch(colorType){
			case 0:
				for (int i = 0; i < 15; i++){
					shotPos = new Vector3(this.transform.position.x + 4, 0, i);
					Instantiate (blueShot, shotSpawn.position + shotPos, new Quaternion(0, 220,0,90));
					shotPos = new Vector3(this.transform.position.x + 35, 0, i);
					Instantiate (blueShot, shotSpawn.position + shotPos, new Quaternion(0, -180,0,90));
				}
				break;
			case 1:
				for (int i = 0; i < 15; i++){
					shotPos = new Vector3(this.transform.position.x + 4, 0, i);
					Instantiate (redShot, shotSpawn.position + shotPos, new Quaternion(0, 220,0,90));
					shotPos = new Vector3(this.transform.position.x + 35, 0, i);
					Instantiate (redShot, shotSpawn.position + shotPos, new Quaternion(0, -180,0,90));
				}
				break;
			case 2:
				for (int i = 0; i < 15; i++){
					shotPos = new Vector3(this.transform.position.x + 4, 0, i);
					Instantiate (yellowShot, shotSpawn.position + shotPos, new Quaternion(0, 220,0,90));
					shotPos = new Vector3(this.transform.position.x + 35, 0, i);
					Instantiate (yellowShot, shotSpawn.position + shotPos, new Quaternion(0, -180,0,90));
				}
				break;
			default: 
				break;
		}
		coolDown = 150;
	}

	//Heals
	public void attack3(){
		this.GetComponent<Done_DestroyByContact> ().hits += 25;
	}
}
