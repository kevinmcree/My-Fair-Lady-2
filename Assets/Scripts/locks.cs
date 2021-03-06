﻿using UnityEngine;
using System.Collections;

/*
This class moves around a series of planes with locks painted on them to represent whether or not the player has unlocked certain content

*/

public class locks : MonoBehaviour {
	public Vector3 outOfWay = new Vector3(500,500,500);
	public int highScore;
	public int[] selectGunVals;
	public int[] selectShipVals;
	public int[] selectModifierVals;

	// Use this for initialization
	void Start () {
		selectGunVals = new int[5];
		selectShipVals = new int[6];
		selectModifierVals = new int[5];

		selectGunVals [0] = 0;
		selectShipVals [0] = 0;
		selectModifierVals [0] = 0;
		selectGunVals [1] = 2000;
		selectShipVals [1] = 2000;
		selectModifierVals [1] = 2000;
		selectGunVals [2] = 5000;
		selectShipVals [2] = 5000;
		selectModifierVals [2] = 5000;
		selectGunVals [3] = 10000;
		selectShipVals [3] = 10000;
		selectModifierVals [3] = 10000;
		selectGunVals [4] = 50000;
		selectShipVals [5] = 50000;
		selectModifierVals [4] = 50000;
		selectShipVals [4] = 100000;

	//	GameObject temp = GameObject.Find ("mod1");
	//	for (int i = 0; i < 4; i++)
	//		selectModifierVals [i] = temp.GetComponent<slelectModifier> ().unlockVals [i];

	//	temp = GameObject.Find ("ship1");
	//	for (int i = 0; i < 6; i++)
	//		selectShipVals [i] = temp.GetComponent<selectShip> ().unlockVals [i];

//		temp = GameObject.Find ("weapon1");
//		for (int i = 0; i < 5; i++)
//			selectGunVals [i] = temp.GetComponent<selectGun> ().unlockVals [i];


	}
	
	void Update () {
		GameObject opt = GameObject.Find ("options");
		GameObject temp;
		highScore = opt.GetComponent<options>().highScore;
		for(int i = 1; i < 5; i++){
			if(highScore > selectModifierVals[i]){
				switch(i){
					case 1:
						temp = GameObject.Find("neverLessThan2Lock");
						temp.transform.position = outOfWay;
						break;
					case 2:
						temp = GameObject.Find("sideGunLock");
						temp.transform.position = outOfWay;
						break;
					case 3:
						temp = GameObject.Find("bulletTimeLock");
						temp.transform.position = outOfWay;
						break;
					case 4:
						temp = GameObject.Find("stopBulletsLock");
						temp.transform.position = outOfWay;
						break;
					default:
						break;
				}
			}
			if(highScore > selectGunVals[i]){
				switch(i){
				case 1:
					temp = GameObject.Find("burstGunLock");
					temp.transform.position = outOfWay;
					break;
				case 2:
					temp = GameObject.Find("chainGunLock");
					temp.transform.position = outOfWay;
					break;
				case 3:
					temp = GameObject.Find("laserLock");
					temp.transform.position = outOfWay;
					break;
				case 4:
					temp = GameObject.Find("rainbowGunLock");
					temp.transform.position = outOfWay;
					break;
				default:
					break;
				}
			}
			
		}
		for (int i = 1; i < 6; i++) {
			if (highScore > selectShipVals [i]) {
				switch (i) {
					case 1:
						temp = GameObject.Find ("heavyShipLock");
						temp.transform.position = outOfWay;
						break;
					case 2:
						temp = GameObject.Find ("fastShipLock");
						temp.transform.position = outOfWay;
						break;
					case 3:
						temp = GameObject.Find ("rainbowShipLock");
						temp.transform.position = outOfWay;
						break;
					case 4:
						temp = GameObject.Find ("carrotShipLock");
						temp.transform.position = outOfWay;
						break;
					case 5:
						temp = GameObject.Find("ikarugaShipLock");
						temp.transform.position = outOfWay;
						break;
				default:
						break;
				}
			}
		}
	}	
}