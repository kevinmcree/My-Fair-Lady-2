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
	public Transform shotSpawn;
	public float fireRate;
	public string playerColor; 
	public int playerHealth;
	private float nextFire;
	public int powerUp;
	public int weapon;
	public bool onScreen;
	public AudioClip[] clips = new AudioClip[7];
	private AudioSource[] audioSources = new AudioSource[7];
	public int stopSpam;
	public bool littleDoctorWait;

	
	void Start ()
	{
		playerColor = "blue";
		int i = 0;
		stopSpam=5;
		while (i < 7) {
			GameObject child = new GameObject("audio");
			child.transform.parent = gameObject.transform;
			audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
			audioSources[i].volume=.8f;
			littleDoctorWait=false;
			
			i++;
		}

	}

	void Update ()
	{
		if (Input.GetKeyDown("space") && Time.time >= nextFire) 
		{
			nextFire = Time.time + fireRate;
		if (weapon==0){
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audioSources[0].clip = clips[0];
			audioSources[0].Play();
			if (powerUp==1){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);
				audioSources[1].clip = clips[1];
				audioSources[1].Play();
			}
			if (powerUp==2){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
				audioSources[2].clip = clips[2];
				audioSources[2].Play();

			}
			if (powerUp==3){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), new Quaternion(0, 20,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), new Quaternion(0, -20,0,90));	
				Instantiate(shot, shotSpawn.position + new Vector3(-1f,0,0), new Quaternion(0, 40,0,90));
				Instantiate(shot, shotSpawn.position + new Vector3(1f,0,0), new Quaternion(0, -40,0,90));
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
			if (littleDoctorWait==false){
					littleDoctorWait=true;
					audioSources[5].clip = clips[5];
					audioSources[5].Play();

			}else{
				Instantiate(chainReaction, shotSpawn.position, shotSpawn.rotation);
				audioSources[6].clip = clips[6];
				audioSources[6].Play();
				littleDoctorWait=false;
			}
		}

		}

		if (Input.GetKeyDown("up") && stopSpam<=0){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			stopSpam=10;

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
		if (Input.GetKeyDown("down") && stopSpam<=0){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			stopSpam=10;

			
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

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = 0;//Input.GetAxis ("Vertical");

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
