using UnityEngine;
using System.Collections;

public class randomizeOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		int random = Random.Range (0, 5);
		if (random==0){
			GameObject explain = GameObject.Find("explainText");
			GameObject ship = GameObject.Find("ship0");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectShip");
			opt.GetComponent<options> ().shipType  = 0;
			select.transform.position = ship.transform.position;
			explain.guiText.text = ship.GetComponent<selectShip>().text;
		}
		else if (random==1){
			GameObject explain = GameObject.Find("explainText");
			GameObject ship = GameObject.Find("ship1");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectShip");
			opt.GetComponent<options> ().shipType  = 1;
			select.transform.position = ship.transform.position;
			explain.guiText.text = ship.GetComponent<selectShip>().text;
		}
		else if (random==2){
			GameObject explain = GameObject.Find("explainText");
			GameObject ship = GameObject.Find("ship2");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectShip");
			opt.GetComponent<options> ().shipType  = 2;
			select.transform.position = ship.transform.position;
			explain.guiText.text = ship.GetComponent<selectShip>().text;
		}
		else if (random==3){
			GameObject explain = GameObject.Find("explainText");
			GameObject ship = GameObject.Find("ship3");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectShip");
			opt.GetComponent<options> ().shipType  = 3;
			select.transform.position = ship.transform.position;
			explain.guiText.text = ship.GetComponent<selectShip>().text;
		}
		else if (random==4){
			GameObject explain = GameObject.Find("explainText");
			GameObject ship = GameObject.Find("ship5");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectShip");
			opt.GetComponent<options> ().shipType  = 5;
			select.transform.position = ship.transform.position;
			explain.guiText.text = ship.GetComponent<selectShip>().text;
		}


		random = Random.Range (0, 5);
		if (random==0){
			GameObject explain = GameObject.Find("explainText");
			GameObject weapon = GameObject.Find("weapon0");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectWeapon");
			opt.GetComponent<options> ().weapon  = 0;
			select.transform.position = weapon.transform.position;
			explain.guiText.text = weapon.GetComponent<selectGun>().text;
		}
		else if (random==1){
			GameObject explain = GameObject.Find("explainText");
			GameObject weapon = GameObject.Find("weapon1");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectWeapon");
			opt.GetComponent<options> ().weapon  = 1;
			select.transform.position = weapon.transform.position;
			explain.guiText.text = weapon.GetComponent<selectGun>().text;
		}
		else if (random==2){
			GameObject explain = GameObject.Find("explainText");
			GameObject weapon = GameObject.Find("weapon2");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectWeapon");
			opt.GetComponent<options> ().weapon  = 2;
			select.transform.position = weapon.transform.position;
			explain.guiText.text = weapon.GetComponent<selectGun>().text;
		}
		else if (random==3){
			GameObject explain = GameObject.Find("explainText");
			GameObject weapon = GameObject.Find("weapon3");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectWeapon");
			opt.GetComponent<options> ().weapon  = 3;
			select.transform.position = weapon.transform.position;
			explain.guiText.text = weapon.GetComponent<selectGun>().text;
		}
		else if (random==4){
			GameObject explain = GameObject.Find("explainText");
			GameObject weapon = GameObject.Find("weapon4");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectWeapon");
			opt.GetComponent<options> ().weapon  = 4;
			select.transform.position = weapon.transform.position;
			explain.guiText.text = weapon.GetComponent<selectGun>().text;
		}

		random = Random.Range (0, 4);
		if (random==0){
			GameObject explain = GameObject.Find("explainText");
			GameObject mod = GameObject.Find("mod0");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectMod");
			opt.GetComponent<options> ().playerModifier = 0;
			select.transform.position = mod.transform.position;
			explain.guiText.text = mod.GetComponent<slelectModifier>().text;
		}
		if (random==1){
			GameObject explain = GameObject.Find("explainText");
			GameObject mod = GameObject.Find("mod1");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectMod");
			opt.GetComponent<options> ().playerModifier = 1;
			select.transform.position = mod.transform.position;
			explain.guiText.text = mod.GetComponent<slelectModifier>().text;
		}
		if (random==2){
			GameObject explain = GameObject.Find("explainText");
			GameObject mod = GameObject.Find("mod2");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectMod");
			opt.GetComponent<options> ().playerModifier = 2;
			select.transform.position = mod.transform.position;
			explain.guiText.text = mod.GetComponent<slelectModifier>().text;
		}
		if (random==3){
			GameObject explain = GameObject.Find("explainText");
			GameObject mod = GameObject.Find("mod3");
			GameObject opt = GameObject.Find("options");
			GameObject select = GameObject.Find("selectMod");
			opt.GetComponent<options> ().playerModifier = 3;
			select.transform.position = mod.transform.position;
			explain.guiText.text = mod.GetComponent<slelectModifier>().text;
		}
		audio.Play();
	}



}
