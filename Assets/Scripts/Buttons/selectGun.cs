using UnityEngine;
using System.Collections;

public class selectGun : MonoBehaviour {
	public int weapon;
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
		GameObject opt = GameObject.Find("options");
		if (opt.GetComponent<options> ().weapon != weapon) {
			opt.GetComponent<options> ().weapon = weapon;
			audioSources [0].clip = clips [0];
			audioSources [0].Play ();
		} else {
			audioSources [1].clip = clips [1];
			audioSources [1].Play ();	
		}
		
	}
}