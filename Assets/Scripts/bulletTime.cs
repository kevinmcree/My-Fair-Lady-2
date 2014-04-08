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
		if (bulletTimeCharge>=30 && Input.GetKeyDown("right ctrl") && yo.GetComponent<Done_PlayerController>().playerModifier == 3){
			toggle = true;
		}

			
		}
	IEnumerator Charge (){
		while(true){
			if (bulletTimeCharge<30){
				bulletTimeCharge++;
			}
			if (toggle==true){
				BulletTime=true;
				yield return new WaitForSeconds (5);
				bulletTimeCharge=0;
				BulletTime=false;
				toggle=false;			
				audio.Play();
			}
			GameObject bulletTimeText = GameObject.Find("bulletTimeChargeCounter");
			bulletTimeText.guiText.text = bulletTimeCharge.ToString();

		yield return new WaitForSeconds (1);
			
		}
		
	}

}

