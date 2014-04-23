using UnityEngine;
using System.Collections;

public class buyBonusMult : MonoBehaviour {
	public int cost;
	
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
		GameObject words = GameObject.Find("BonusCost");
		words.GetComponent<TextMesh>().text = "" +cost;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		GameObject go = GameObject.Find("Game Controller");
		if (go.GetComponent<Done_GameController>().score>=cost){
			go.GetComponent<Done_GameController>().comboExtender +=50;
			go.GetComponent<Done_GameController>().AddScore(-(cost/go.GetComponent<Done_GameController>().scoreMultiplier));
			cost=cost*5;
			audioSources[0].clip = clips[0];
			audioSources[0].Play();
			GameObject words = GameObject.Find("BonusCost");
			words.GetComponent<TextMesh>().text = "" +cost;
			
		}else{
			audioSources[1].clip = clips[1];
			audioSources[1].Play();
		}
	}
}