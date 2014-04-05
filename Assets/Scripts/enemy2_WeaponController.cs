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
		Instantiate(shot, shotSpawn.position + new Vector3(1f, 0, 0), shotSpawn.rotation);
		Instantiate(shot, shotSpawn.position + new Vector3(0, 0, 0), shotSpawn.rotation);
		Instantiate(shot, shotSpawn.position + new Vector3(-1f, 0, 0), shotSpawn.rotation);
		audio.Play ();
	}
}
