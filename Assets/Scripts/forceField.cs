using UnityEngine;
using System.Collections;

public class forceField : MonoBehaviour {
	public bool ForceField;
	public int fieldCharge;
	public bool toggle;
	GameObject yo;
	// Use this for initialization
	void Start () {
		yo = GameObject.Find ("Player");

		StartCoroutine (Charge());

		
	}
	
	// Update is called once per frame
	void Update () {
		if (fieldCharge>=30 && Input.GetKeyDown("return") && yo.GetComponent<Done_PlayerController>().playerModifier == 4){
			toggle = true;
		}
		
		
	}
	IEnumerator Charge (){
		while(true){
			if (yo.GetComponent<Done_PlayerController>().playerModifier == 4 && fieldCharge<30){
				fieldCharge++;
			}
			if (toggle==true){
				ForceField=true;
				yield return new WaitForSeconds (1);
				fieldCharge=0;
				ForceField=false;
				toggle=false;			
				audio.Play();
			}
			if (yo.GetComponent<Done_PlayerController>().playerModifier == 4){
					GameObject bulletTimeText = GameObject.Find("bulletTimeChargeCounter");
				bulletTimeText.guiText.text = fieldCharge.ToString();
			}
			
			yield return new WaitForSeconds (1);
			
		}
		
	}
	
}

