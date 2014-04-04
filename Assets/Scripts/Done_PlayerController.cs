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
	public Transform shotSpawn;
	public float fireRate;
	public string playerColor; 
	public int playerHealth;
	private float nextFire;
	public int powerUp;

	void Start ()
	{
		playerColor = "blue";
	}

	void Update ()
	{
		if (Input.GetKeyDown("space") && Time.time >= nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			if (powerUp==1){
				Instantiate(shot, shotSpawn.position + new Vector3(-.5f,0,0), shotSpawn.rotation);
				Instantiate(shot, shotSpawn.position + new Vector3(.5f,0,0), shotSpawn.rotation);
			}

			audio.Play ();
		}

		if (Input.GetKeyDown("up")){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");


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
		if (Input.GetKeyDown("down")){
			GameObject red = GameObject.Find("Red");
			GameObject yellow = GameObject.Find("Yellow");
			GameObject blue = GameObject.Find("Blue");
			
			
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
