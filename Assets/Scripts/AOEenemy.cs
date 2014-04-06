using UnityEngine;
using System.Collections;

public class AOEenemy : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire ()
	{
		if (transform.position.z>=-4)
		{
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 0,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 20,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 40,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 60,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 80,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 100,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 120,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 140,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 160,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 180,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 200,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 220,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 240,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 260,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 280,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 400,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 500,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 600,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 700,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -20,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -40,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -60,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -80,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -100,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -120,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -140,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -160,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -180,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -200,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -220,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -240,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -260,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -280,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -400,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -50,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -600,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -700,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 10,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 30,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 50,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 70,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 90,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 110,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 130,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 150,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 170,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 190,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 210,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 230,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 250,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 270,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 290,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 800,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 900,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 1000,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, 10,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -30,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -50,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -70,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -90,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -110,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -130,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -150,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -170,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -190,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -210,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -230,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -250,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -270,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -800,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -900,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -1000,0,90));
			Instantiate(shot, shotSpawn.position, new Quaternion(0, -1100,0,90));
			audio.Play();
		}
	}
}
