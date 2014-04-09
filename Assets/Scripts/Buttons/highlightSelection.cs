using UnityEngine;
using System.Collections;

public class highlightSelection : MonoBehaviour {
	GameObject opt;
	GameObject selecMod;
	GameObject selecShip;
	GameObject selecWeapon;
	void Start () {
		 opt = GameObject.Find("options");
		 selecMod= GameObject.Find("selectMod");
		 selecShip= GameObject.Find("selectShip");
		 selecWeapon= GameObject.Find("selectWeapon");

	
	}
	
	// Update is called once per frame
	void Update () {
		if (opt.GetComponent<options>().shipType ==0){
			selecMod.transform.position=GameObject.Find("ship0").transform.position;
		} else if (opt.GetComponent<options>().shipType ==1){
			selecMod.transform.position=GameObject.Find("ship1").transform.position;
		} else if (opt.GetComponent<options>().shipType ==2){
			selecMod.transform.position=GameObject.Find("ship2").transform.position;
		} else if (opt.GetComponent<options>().shipType ==3){
			selecMod.transform.position=GameObject.Find("ship3").transform.position;
		} else if (opt.GetComponent<options>().shipType ==4){
			selecMod.transform.position=GameObject.Find("ship4").transform.position;
		} else if (opt.GetComponent<options>().shipType ==5){
			selecMod.transform.position=GameObject.Find("ship5").transform.position;
		}

		if (opt.GetComponent<options>().weapon == 0){
			selecWeapon.transform.position=GameObject.Find("weapon0").transform.position;
		} else if (opt.GetComponent<options>().weapon == 1){
			selecWeapon.transform.position=GameObject.Find("weapon1").transform.position;
		} else if (opt.GetComponent<options>().weapon == 2){
			selecWeapon.transform.position=GameObject.Find("weapon2").transform.position;
		} else if (opt.GetComponent<options>().weapon == 3){
			selecWeapon.transform.position=GameObject.Find("weapon3").transform.position;
		} else if (opt.GetComponent<options>().weapon == 4){
			selecWeapon.transform.position=GameObject.Find("weapon4").transform.position;
		}

		if (opt.GetComponent<options>().playerModifier == 0){
			selecShip.transform.position=GameObject.Find("mod0").transform.position;
		} else if (opt.GetComponent<options>().playerModifier == 1){
			selecShip.transform.position=GameObject.Find("mod1").transform.position;
		} else if (opt.GetComponent<options>().playerModifier == 2){
			selecShip.transform.position=GameObject.Find("mod2").transform.position;
		} else if (opt.GetComponent<options>().playerModifier == 3){
			selecShip.transform.position=GameObject.Find("mod3").transform.position;
		}
	}


}
