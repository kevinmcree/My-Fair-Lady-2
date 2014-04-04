using UnityEngine;
using System.Collections;

public class enemy2_WeaponController : MonoBehaviour
{
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
				Instantiate(shot, shotSpawn.position + new Vector3(0, 10, 0), shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position + new Vector3(0, 10, 0), shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position + new Vector3(0, 10, 0), shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position + new Vector3(0, 10, 0), shotSpawn.rotation);
				//Instantiate(shot, shotSpawn.position, new Quaternion(0, 20,0,90));
				//Instantiate(shot, shotSpawn.position, new Quaternion(0, -20,0,90));	
				//Instantiate(shot, shotSpawn.position, new Quaternion(0, 40,0,90));
				//Instantiate(shot, shotSpawn.position, new Quaternion(0, -40,0,90));
				audio.Play ();
	}
}
