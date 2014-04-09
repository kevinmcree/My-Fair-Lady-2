using UnityEngine;
using System.Collections;

public class BuySheild : MonoBehaviour {
	public bool toggle = false;
	public GameObject sheild;
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

	void OnMouseUp(){
		GameObject go = GameObject.Find("Game Controller");
		GameObject xo = GameObject.Find("Player");
		GameObject yo = GameObject.Find ("player_sheild(Clone)");

		if (go.GetComponent<Done_GameController>().score>=5000){
			if (xo.GetComponent<Done_PlayerController> ().hasShield == false) {
				Instantiate (sheild, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
				xo.GetComponent<Done_PlayerController>().hasShield=true;
				go.GetComponent<Done_GameController>().AddScore(-(5000/go.GetComponent<Done_GameController>().scoreMultiplier));
				audioSources[0].clip = clips[0];
				audioSources[0].Play();
			} else if (yo.GetComponent<sheild>().sheildHealth<=3){
				yo.GetComponent<sheild> ().sheildHealth++;
				go.GetComponent<Done_GameController>().AddScore(-(5000/go.GetComponent<Done_GameController>().scoreMultiplier));
				audioSources[0].clip = clips[0];
				audioSources[0].Play();
			}else{
				audioSources[1].clip = clips[1];
				audioSources[1].Play();
			}
		}else{
			audioSources[1].clip = clips[1];
			audioSources[1].Play();
		}


	}
}
