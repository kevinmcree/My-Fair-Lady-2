using UnityEngine;
using System.Collections;

public class forceField : MonoBehaviour {
	public bool ForceField;
	public int fieldCharge;
	public bool toggle;
	public GameObject yo;
	public GameObject fieldBurst;
	// Use this for initialization
	void Start () {
		yo = GameObject.Find ("Player");

		StartCoroutine (Charge());

		
	}
	
	// Update is called once per frame
	void Update () {
		if (fieldCharge>=30 && Input.GetKeyDown("return") && yo.GetComponent<Done_PlayerController>().playerModifier == 4){
			Instantiate(fieldBurst, transform.position, transform.rotation);
			audio.Play();
			ForceField=true;
			toggle = true;
		}
		
		
	}
	IEnumerator Charge (){
		while(true){
			if (yo.GetComponent<Done_PlayerController>().playerModifier == 4 && fieldCharge<30){
				fieldCharge++;
			}
			if (toggle==true){
			yield return new WaitForSeconds (1);
				fieldCharge=0;
				ForceField=false;
				toggle=false;			
			}
			if (yo.GetComponent<Done_PlayerController>().playerModifier == 4){
					GameObject bulletTimeText = GameObject.Find("bulletTimeChargeCounter");
				bulletTimeText.guiText.text = fieldCharge.ToString();
			}
			
			yield return new WaitForSeconds (1);
			
		}
		
	}
	
}

