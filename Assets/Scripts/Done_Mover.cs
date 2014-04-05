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
		if (transform.position.z>=20)
		{
			Destroy (gameObject);
		}
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().inStore==true){
			Destroy (gameObject);
		}

	}

}
