using UnityEngine;
using System.Collections;

public class slelectModifier : MonoBehaviour {

		public int mod;
		// Use this for initialization
		public AudioClip[] clips = new AudioClip[2];
		private AudioSource[] audioSources = new AudioSource[2];
		public string text;
		
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
			if (opt.GetComponent<options> ().playerModifier  != mod) {
				opt.GetComponent<options> ().playerModifier  = mod;
				audioSources [0].clip = clips [0];
				audioSources [0].Play ();
			} else {
				audioSources [1].clip = clips [1];
				audioSources [1].Play ();	
			}
		GameObject explain = GameObject.Find("explainText");
		explain.guiText.text = text;
			
		}
		
	}