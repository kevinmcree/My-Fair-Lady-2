using UnityEngine;
using System.Collections;

public class bulletTime : MonoBehaviour {
	public bool BulletTime;
	public int bulletTimeCharge;
	public bool toggle;
	// Use this for initialization
	void Start () {

		StartCoroutine (Charge());

	}
	
	// Update is called once per frame
	void Update () {
		GameObject yo = GameObject.Find ("Player");

		if (bulletTimeCharge>=30 && Input.GetKeyDown("return") && yo.GetComponent<Done_PlayerController>().playerModifier == 3){
			toggle = true;
		}

			
		}
	IEnumerator Charge (){
		while(true){
			GameObject yo = GameObject.Find ("Player");

			if (yo.GetComponent<Done_PlayerController>().playerModifier == 3 && bulletTimeCharge<30){
				bulletTimeCharge++;
			}
			if (toggle==true){
				BulletTime=true;
				audio.Play();

				yield return new WaitForSeconds (5);
				bulletTimeCharge=0;
				BulletTime=false;
				toggle=false;			
			}
			if (yo.GetComponent<Done_PlayerController>().playerModifier == 3){
				GameObject bulletTimeText = GameObject.Find("bulletTimeChargeCounter");
				bulletTimeText.guiText.text = bulletTimeCharge.ToString();
			}

		yield return new WaitForSeconds (1);
			
		}
		
	}

}

