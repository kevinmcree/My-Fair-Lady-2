using UnityEngine;
using System.Collections;

public class powerUpVaccum : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("Player");
		if (go.GetComponent<Done_PlayerController>().vaccum==true){
			if (this.transform.position.x>go.transform.position.x){ 
				this.transform.position -= new Vector3 (.1f,0,.1f);
			}
			if (this.transform.position.x<go.transform.position.x){ 
				this.transform.position += new Vector3 (.1f,0,-.1f);
			}
		}
	
	}
}
