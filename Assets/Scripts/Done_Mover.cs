using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
	void Update ()
	{
		if (transform.position.z>=20 || transform.position.z<=-20 ||transform.position.x>=20 || transform.position.x<=-20 )
		{
			Destroy (gameObject);
			if (this.tag=="projectile" || this.tag=="rainbow"){
				GameObject yo = GameObject.Find("Player");
				yo.GetComponent<Done_PlayerController>().shotAmount--;
			}
		}
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().inStore==true){
			Destroy (gameObject);
		}

	}

}
