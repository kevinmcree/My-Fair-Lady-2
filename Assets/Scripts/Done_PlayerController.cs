using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public GameObject blast;
	public GameObject chainReaction;
	public GameObject rainbow;
	public Transform shotSpawn;
	public float fireRate;
	public string playerColor; 
	public int playerHealth;
	public float maxHealth;
	private float nextFire;
	public int powerUp;
	public int shipType;
	public int weapon;
	public bool onScreen;
	public AudioClip[] clips = new AudioClip[8];
	private AudioSource[] audioSources = new AudioSource[8];
	public int stopSpam;
	public int littleDoctorWait;
	public int hitStun;
	public int shotAmount;
	public bool hasShield;
	public int playerModifier;
	public int bombCharge;


	
	void Start ()
	{
		GameObject opt = GameObject.Find("options");
		weapon = opt.GetComponent<options> ().weapon;
		shipType = opt.GetComponent<options> ().shipType;	
		playerModifier = opt.GetComponent<options> ().playerModifier;

		if (weapon==1){
			fireRate=1;
		}
		if (shipType == 0) {
			speed = 18;
			playerHealth = 4;
			maxHealth = 4f;
		}
		if (shipType == 1) {
			speed = 10;
			playerHealth = 6;
			maxHealth = 6f;
		}
		if (shipType == 2) {
			speed = 30;
			playerHealth = 2;
			maxHealth  = 2f;
			transform.localScale = new Vector3 (.7f,.75f,1.25f);
		}
		if (shipType == 3) {
			speed = 15;
			playerHealth = 3;
			maxHealth  = 3f;			
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			red.transform.position = new Vector3(100,-9,1);
			yellow.transform.position = new Vector3(100,-9,1);
			blue.transform.position = new Vector3(100,-11,1);

		}
		if (shipType == 4) {
			speed = 0;
			playerHealth = 2;
			maxHealth  = 2f;			
			GameObject carrot = GameObject.Find("carrot");
			carrot.transform.position = this.transform.position;
			gameObject.transform.position = new Vector3 (100000,100000,1000000);


		}
		if (shipType == 5) {
			GameObject chargeText = GameObject.Find("bombChargeCounter");
			chargeText.transform.position = new Vector3 (.9f,.24f,0);
			speed = 20;
			playerHealth = 4;
			maxHealth = 4f;
		}else{
			GameObject chargeText = GameObject.Find("bombChargeCounter");
			chargeText.transform.position = new Vector3 (100f,100f,100);
		}
		if (playerModifier == 1) {
						powerUp = 1;
				}
		if (playerModifier == 3) {
			GameObject bulletTimeText = GameObject.Find("bulletTimeChargeCounter");
			bulletTimeText.transform.position= new Vector3 (.9f,.24f,0);

		}


		playerColor = "blue";
		littleDoctorWait=100;
		int i = 0;
		stopSpam=5;
		while (i < 8) {
			GameObject child = new GameObject("audio");
			child.transform.parent = gameObject.transform;
			audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
			audioSources[i].volume=.8f;

			i++;
		}

	}

	void Update ()
	{
		if (shotAmount<0){
			shotAmount=0;
		}

		if (playerModifier == 1 && powerUp<1) {
			powerUp = 1;
		}

		if (shipType == 4) {
			gameObject.transform.position = new Vector3 (100000, 100000, 1000000);
		}
			hitStun--;
		if (Input.GetKeyDown("space") && Time.time >= nextFire && shotAmount<=500 && shipType!=4) 
		{
			if (playerModifier==2){
				if (powerUp==0){
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 100,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -100,0,90));
					shotAmount+=2;

				}
				if (powerUp==1){
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 100,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -100,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 80,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -80,0,90));
					shotAmount+=4;
					
				}
				if (powerUp==2){
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 80,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -80,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 90,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -90,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 100,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -100,0,90));
					shotAmount+=6;
									
				}
				if (powerUp==3){
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 70,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -70,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 80,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -80,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 90,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -90,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 100,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -100,0,90));
					shotAmount+=8;
					
				}
				if (powerUp==4){
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 70,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -70,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 50,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -50,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 90,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -90,0,90));	
					Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 110,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -110,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, -120,0,90));
					Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, 120,0,90));	

					shotAmount+=10;
					
				}
			}
				nextFire = Time.time + fireRate;
		if (weapon==0){
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			shotAmount+=1;
			audioSources[0].clip = clips[0];
			audioSources[0].Play();
			if (powerUp==1){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);
					shotAmount+=3;
				audioSources[1].clip = clips[1];
				audioSources[1].Play();
			}
			if (powerUp==2){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
					shotAmount+=5;

				audioSources[2].clip = clips[2];
				audioSources[2].Play();

			}
			if (powerUp==3){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, 10,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, -10,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), new Quaternion(0, 20,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), new Quaternion(0, -20,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), new Quaternion(0, 40,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), new Quaternion(0, -40,0,90));
					shotAmount+=11;

				audioSources[3].clip = clips[3];
				audioSources[3].Play();

					
			}
			if (powerUp>=4){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(2f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, 10,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, -10,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), new Quaternion(0, 20,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), new Quaternion(0, -20,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), new Quaternion(0, 40,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), new Quaternion(0, -40,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(-1.5f,0,0), new Quaternion(0, 60,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(1.5f,0,0), new Quaternion(0, -60,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 80,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -80,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(-2f,0,0), new Quaternion(0, 100,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(2,0,0), new Quaternion(0, -100,0,90));

					shotAmount+=20;

				audioSources[4].clip = clips[4];
				audioSources[4].Play();
			}
		}
		if (weapon==1){
			if (onScreen==false){
				Instantiate(blast, shotSpawn.position, shotSpawn.rotation);
				audioSources[0].clip = clips[0];
				audioSources[0].Play();
					onScreen=true;
			}
		}
		if (weapon==2){		
			if (littleDoctorWait==100 ){
				audioSources[5].clip = clips[5];
				audioSources[5].Play();
				littleDoctorWait=30;
			}

			if (littleDoctorWait<=0){ 
				Instantiate(chainReaction, shotSpawn.position, shotSpawn.rotation);
				audioSources[6].clip = clips[6];
				audioSources[6].Play();
				littleDoctorWait=100;
			}
		}
		
		if (weapon==4){
					if (powerUp==0){
						Instantiate(rainbow, shotSpawn.position, shotSpawn.rotation);
						shotAmount+=1;
						audioSources[7].clip = clips[7];
						audioSources[7].Play();
					}

					if (powerUp==1){
						Instantiate(rainbow, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);
						shotAmount+=2;
						audioSources[7].clip = clips[7];
						audioSources[7].Play();
					}
					if (powerUp==2){
						Instantiate(rainbow, shotSpawn.position + new Vector3(0,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(-1.5f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(1.5f,0,0), shotSpawn.rotation);
						shotAmount+=3;
						audioSources[7].clip = clips[7];
						audioSources[7].Play();
						
					}
					if (powerUp==3){
						Instantiate(rainbow, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);	
						Instantiate(rainbow, shotSpawn.position + new Vector3(0f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(-.5f,0,0), new Quaternion(0, 20,0,90));
						Instantiate(rainbow, shotSpawn.position + new Vector3(.5f,0,0), new Quaternion(0, -20,0,90));	
						shotAmount+=5;
						
						audioSources[7].clip = clips[7];
						audioSources[7].Play();
						
						
					}
					if (powerUp>=4){
						Instantiate(rainbow, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
						Instantiate(rainbow, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
						Instantiate(rainbow, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, 10,0,90));
						Instantiate(rainbow, shotSpawn.position + new Vector3(0,0,0), new Quaternion(0, -10,0,90));	
						Instantiate(rainbow, shotSpawn.position + new Vector3(-.5f,0,0), new Quaternion(0, 20,0,90));
						Instantiate(rainbow, shotSpawn.position + new Vector3(.5f,0,0), new Quaternion(0, -20,0,90));	
						shotAmount+=8;
						
						audioSources[7].clip = clips[7];
						audioSources[7].Play();
				}
			}


		}
		if (Input.GetKeyDown("right ctrl") && shipType==5 && bombCharge>=10){
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 5,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 10,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 15,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 20,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 25,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 30,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 35,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 40,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 45,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 50,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 55,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 60,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 65,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 70,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 75,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 80,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 85,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 90,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 95,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 100,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 105,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 110,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 115,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 120,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 125,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 130,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 135,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 140,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 145,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 150,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 155,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 160,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 165,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 170,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 175,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 180,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 185,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 190,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 195,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 200,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 205,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 210,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 215,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 220,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 225,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 230,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 235,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 240,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 245,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 250,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 255,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 260,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 265,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 270,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 275,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 280,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 285,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 290,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 295,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 300,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 305,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 310,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 315,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 320,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 325,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 330,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 335,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 340,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 345,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 350,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 355,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, 360,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -5,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -10,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -15,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -20,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -25,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -30,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -35,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -40,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -45,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -50,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -55,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -60,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -65,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -70,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -75,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -80,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -85,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -90,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -95,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -100,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -105,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -110,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -115,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -120,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -125,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -130,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -135,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -140,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -145,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -150,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -155,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -160,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -165,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -170,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -175,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -180,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -185,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -190,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -195,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -200,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -205,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -210,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -215,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -220,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -225,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -230,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -235,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -240,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -245,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -250,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -255,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -260,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -265,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -270,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -275,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -280,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -285,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -290,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -295,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -300,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -305,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -310,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -315,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -320,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -325,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -330,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -335,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -340,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -345,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -350,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -355,0,90));
			Instantiate(chainReaction, this.transform.position, new Quaternion(0, -360,0,90));
			shotAmount+=144;
			bombCharge=0;
			UpdateCharge ();
		}


		if (littleDoctorWait!=100){
			littleDoctorWait--;
			
		}

		if (Input.GetKeyDown("up") && stopSpam<=0 && shipType!=3 ){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			if (shipType != 4){
				stopSpam=10;
			}

			if (String.Compare(playerColor, "blue")==0){
				red.transform.position = new Vector3(0,-9,1);
				blue.transform.position = new Vector3(0,-11,1);
				playerColor = "red";
			}		
			else if (String.Compare(playerColor, "red")==0){
				yellow.transform.position = new Vector3(0,-9,1);
				red.transform.position = new Vector3(0,-11,1);
				playerColor = "yellow";
			}
			else if (String.Compare(playerColor, "yellow")==0){
				blue.transform.position = new Vector3(0,-9,1);
					yellow.transform.position = new Vector3(0,-11,1);
				playerColor = "blue";
			}
		}
		if (Input.GetKeyDown("down") && stopSpam<=0 && shipType!=3){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			if (shipType != 4){
				stopSpam=10;
			}

			
			if (String.Compare(playerColor, "blue")==0){
				yellow.transform.position = new Vector3(0,-9,1);
				blue.transform.position = new Vector3(0,-11,1);
				playerColor = "yellow";

			}		
			else if (String.Compare(playerColor, "red")==0){
				blue.transform.position = new Vector3(0,-9,1);
				red.transform.position = new Vector3(0,-11,1);
				playerColor = "blue";
			}
			else if (String.Compare(playerColor, "yellow")==0){
				red.transform.position = new Vector3(0,-9,1);
				yellow.transform.position = new Vector3(0,-11,1);
				playerColor = "red";
			}
		}
		stopSpam--;


	}
	public void addBombCharge(){
		bombCharge++;
		UpdateCharge ();
	}

	void UpdateCharge(){
		GameObject chargeText = GameObject.Find("bombChargeCounter");
		chargeText.guiText.text = bombCharge.ToString();
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = 0;//Input.GetAxis ("Vertical");

		if (shipType == 3) {
			 moveVertical = Input.GetAxis ("Vertical");
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			-3f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
