﻿using UnityEngine;
using System.Collections;

public class buyRainbow : MonoBehaviour {
	// Use this for initialization
	public AudioClip[] clips = new AudioClip[2];
	private AudioSource[] audioSources = new AudioSource[2];
	
	// Use this for initialization
	void Start () {
		int i = 0;
		while (i < 2) {
			GameObject child = new GameObject("audio");
			child.transform.parent = gameObject.transform;
			audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
			audioSources[i].volume=.8f;
			i++;
		}
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		GameObject yo = GameObject.Find("Player");
		if (yo.GetComponent<Done_PlayerController>().weapon!=4 && go.GetComponent<Done_GameController>().score>=20000){
			yo.GetComponent<Done_PlayerController>().weapon=4;
			go.GetComponent<Done_GameController>().AddScore(-20000/go.GetComponent<Done_GameController>().scoreMultiplier);
			audioSources[0].clip = clips[0];
			audioSources[0].Play();
		}else{
			audioSources[1].clip = clips[1];
			audioSources[1].Play();	
		}
	}
}