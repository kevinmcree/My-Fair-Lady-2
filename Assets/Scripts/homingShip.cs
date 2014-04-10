using UnityEngine;
using System.Collections;

public class homingShip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("Player");
			if (this.transform.position.x>go.transform.position.x){ 
				this.transform.position -= new Vector3 (.12f,0,0);
			}
			if (this.transform.position.x<go.transform.position.x){ 
				this.transform.position += new Vector3 (.12f,0, 0);
			}
		this.transform.position = new Vector3 (this.transform.position.x, -3, this.transform.position.z);
	}
}
