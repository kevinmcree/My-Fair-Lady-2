using UnityEngine;
using System.Collections;

/*
Dear Kevin,
	I'm writing you another note to let you know what has changed here.
	I have added a check in the OnMouseDown funtion that only allows the player to select a modifier if their high score
	as determined in the options script has reached a certain threshold

*/

public class slelectModifier : MonoBehaviour {

	public int mod;
	// Use this for initialization
	public AudioClip[] clips = new AudioClip[2];
	private AudioSource[] audioSources = new AudioSource[2];
	public string text;
	public GameObject particles;
	public int[] unlockVals = new int[5];


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
		unlockVals[0] = 0;
		unlockVals[1] = 2000;
		unlockVals[2] = 5000;
		unlockVals[3] = 10000;
		unlockVals[4] = 20000;
	}
		
		
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		GameObject opt = GameObject.Find("options");
		if (opt.GetComponent<options> ().playerModifier  != mod) {
			GameObject explain = GameObject.Find("explainText");
			switch(mod){
				case 0:
					opt.GetComponent<options> ().playerModifier  = mod;
					audioSources [0].clip = clips [0];
					audioSources [0].Play ();
					Instantiate(particles, this.transform.position, transform.rotation);
					explain.guiText.text = text;

					break;
				case 1:
					if(opt.GetComponent<options>().highScore >= unlockVals[1]){
						opt.GetComponent<options> ().playerModifier  = mod;
						audioSources [0].clip = clips [0];
						audioSources [0].Play ();
						Instantiate(particles, this.transform.position, transform.rotation);
						explain.guiText.text = text;

					}
					else{
						audioSources [1].clip = clips [1];
						audioSources [1].Play ();
						explain.guiText.text = "Not Unlocked";

					}
					break;
				case 2:
				if(opt.GetComponent<options>().highScore >= unlockVals[2]){
						opt.GetComponent<options> ().playerModifier  = mod;
						audioSources [0].clip = clips [0];
						audioSources [0].Play ();
						Instantiate(particles, this.transform.position, transform.rotation);
						explain.guiText.text = text;

					}
					else{
						audioSources [1].clip = clips [1];
						audioSources [1].Play ();
						explain.guiText.text = "Not Unlocked";

					}
					break;
				case 3:
				if(opt.GetComponent<options>().highScore >= unlockVals[3]){
						opt.GetComponent<options> ().playerModifier  = mod;
						audioSources [0].clip = clips [0];
						audioSources [0].Play ();
						Instantiate(particles, this.transform.position, transform.rotation);
						explain.guiText.text = text;

					}
					else{
						audioSources [1].clip = clips [1];
						audioSources [1].Play ();
						explain.guiText.text = "Not Unlocked";

					}
					break;
				case 4:
				if(opt.GetComponent<options>().highScore >= unlockVals[4]){
						opt.GetComponent<options> ().playerModifier  = mod;
						audioSources [0].clip = clips [0];
						audioSources [0].Play ();
						Instantiate(particles, this.transform.position, transform.rotation);
						explain.guiText.text = text;

					}
					else{
						audioSources [1].clip = clips [1];
						audioSources [1].Play ();
						explain.guiText.text = "Not Unlocked";

					}
					break;
				default:
					audioSources [1].clip = clips [1];
					audioSources [1].Play ();
					explain.guiText.text = "Not Unlocked";

					break;
			}


		}
		else {
			audioSources [1].clip = clips [1];
			audioSources [1].Play ();	
		}

	}

}