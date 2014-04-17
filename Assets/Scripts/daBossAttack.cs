using UnityEngine;
using System.Collections;

public class daBossAttack : MonoBehaviour {

	public GameObject redShot;
	public GameObject blueShot;
	public GameObject yellowShot;
	public Transform shotSpawn;

	public int coolDown;
	public int attackCol;
	public int attackType;

	void Start () {
		coolDown = 0;
	}
	
	//Each frame the boss attack cooldown decrements
	//If the cooldown is <= 0 the boss randomizes an attack type and color
	//then executes the attack in the chosen color
	void Update () {
		//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		if (coolDown <= 0) {
			attackCol = Random.Range (0, 2);
			attackType = Random.Range (0, 2);


			attackType = 0;

			/*switch(attackCol){
				case 0:
					shot = GameObject.Find ("Enemy_Shot_Blue");
					break;
				case 1:
					shot = GameObject.Find ("Enemy_Shot_Red");
					break;	
				case 2:
					shot = GameObject.Find ("Enemy_Shot_Yellow");
					break;
			}*/
			
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
		coolDown = 50;
	}
	public void attack2(){

	}
	public void attack3(){

	}
}
