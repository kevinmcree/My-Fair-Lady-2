using UnityEngine;
using System.Collections;

public class daBossAttack : MonoBehaviour {

	public GameObject redShot;
	public GameObject blueShot;
	public GameObject yellowShot;
	public Transform shotSpawn;
	public Transform shotAngle;
	public Material blue;
	public Material red;
	public Material yellow;
	public int coolDown;
	public int attackCol;
	public int attackType;
	public int colorChange;
	public int laserAttack;

	void Start () {
		GameObject yo = GameObject.Find ("Game Controller");
		GameObject laser = GameObject.Find ("bossLaser");
		laserAttack = 0;
		laser.transform.position = new Vector3 (-100, -3, 100);

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
			GameObject laser = GameObject.Find ("bossLaser");
			GameObject yo = GameObject.Find ("Game Controller");
			yo.GetComponent<Done_GameController>().audio.Play();
			yo.GetComponent<Done_GameController>().boss = false;
			yo.GetComponent<Done_GameController>().isBoss = false;
			yo.GetComponent<Done_GameController>().bossSource[0].Pause();
			yo.GetComponent<Done_GameController>().range--;
			laser.transform.position = new Vector3 (-100, -3, 100);
		
			Destroy (gameObject);
		}
		if (laserAttack<0){
			GameObject laser = GameObject.Find ("bossLaser");
			if (laserAttack == 1){
				if (laser.transform.position.x>=3.5f){
					laser.transform.position = new Vector3 (-100, -3, 100);
					laserAttack = 0;
				}
				laser.transform.position += new Vector3 (.1f, 0, 0);
			}
			if (laserAttack == 2){
				if (laser.transform.position.x<=-5){
					laser.transform.position = new Vector3 (-100, -3, 100);
					laserAttack = 0;
				}
				laser.transform.position += new Vector3 (-.1f, 0, 0);
			}
		}
				//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		if (coolDown <= 0) {


			colorChange = Random.Range (0, 3);
			attackCol = Random.Range (0, 3);
			attackType = Random.Range (0, 3);

			//attackType = 1;
			
			switch(colorChange){
			case 0:
				renderer.material = blue;
				this.GetComponent<Done_DestroyByContact>().color="blue";
				break;
			case 1:
				renderer.material = red;
				this.GetComponent<Done_DestroyByContact>().color="red";
				break;
			case 2:
				renderer.material = yellow;
				this.GetComponent<Done_DestroyByContact>().color="yellow";
				break;
			default:
				break;
			}
		
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
				case 3:
					attack4 ();
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

	//Shoots diagonal shots
	public void attack3(){
		GameObject laser = GameObject.Find ("bossLaser");
		int rand = Random.Range (0,2);
		if (rand==1){
			laserAttack=0;
			laser.transform.position = new Vector3 (-15, -3, .6f);
		}
		if (rand==2){
			laserAttack=1;
			laser.transform.position = new Vector3 (5, -3, .6f);
		}
		coolDown = 500;

	}



	//Heals
	public void attack4(){
		this.GetComponent<Done_DestroyByContact> ().hits += 25;
	}
}
