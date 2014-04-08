using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public bool toggle;

	public float speed;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
	void Update ()
	{	
		GameObject yo = GameObject.Find("Player");
		if (transform.position.z>=20 || transform.position.z<=-20 ||transform.position.x>=20 || transform.position.x<=-20 )
		{
			Destroy (gameObject);
			if (this.tag=="projectile" || this.tag=="rainbow" || this.name == "burst(Clone)"){
				yo.GetComponent<Done_PlayerController>().shotAmount--;
				yo.GetComponent<Done_PlayerController>().onScreen=false;

			}
		}
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().inStore==true){
			Destroy (gameObject);
		}			

		if (yo.GetComponent<bulletTime>().BulletTime==true && toggle == false){
				rigidbody.velocity = (transform.forward * speed)/10;
			toggle=true;
		}
		if (yo.GetComponent<bulletTime>().BulletTime==false && toggle == true){
			rigidbody.velocity = transform.forward * speed;
			toggle=false;
		}

		
		
		}

}
