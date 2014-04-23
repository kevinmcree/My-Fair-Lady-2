using UnityEngine;
using System.Collections;

public class buyScoreMult : MonoBehaviour {
	public int cost;
	public AudioClip[] clips = new AudioClip[2];
	private AudioSource[] audioSources = new AudioSource[2];
	
	// Use this for initialization

		

	// Use this for initialization
	void Start () {
		GameObject words = GameObject.Find("ScoreCost");
		words.GetComponent<TextMesh>().text = " " +cost;
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
		if (go.GetComponent<Done_GameController>().score>=cost){
			go.GetComponent<Done_GameController>().scoreMultiplier = go.GetComponent<Done_GameController>().scoreMultiplier*2;
			go.GetComponent<Done_GameController>().AddScore(-(cost/go.GetComponent<Done_GameController>().scoreMultiplier));
			audioSources[0].clip = clips[0];
			audioSources[0].Play();
			GameObject words = GameObject.Find("ScoreCost");
			words.GetComponent<TextMesh>().text = "" +cost;
			cost=cost*5;
		}else{
			audioSources[1].clip = clips[1];
			audioSources[1].Play();
		}

	}
}

