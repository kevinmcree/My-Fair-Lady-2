using UnityEngine;
using System.Collections;

/*
Kevin,
I did the same thing here that I did in the selectmodifier script
*/


public class selectGun : MonoBehaviour {
	public int weapon;
	public AudioClip[] clips = new AudioClip[2];
	private AudioSource[] audioSources = new AudioSource[2];
	public string text;
	public GameObject particles;


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
			switch(weapon){
			case 0:
				opt.GetComponent<options> ().weapon = weapon;
				audioSources [0].clip = clips [0];
				audioSources [0].Play ();
				Instantiate(particles, this.transform.position, transform.rotation);
				break;
			case 1:
				if(opt.GetComponent<options>().highScore > 1000){
					opt.GetComponent<options> ().weapon = weapon;
					audioSources [0].clip = clips [0];
					audioSources [0].Play ();
					Instantiate(particles, this.transform.position, transform.rotation);
				}
				else{
					audioSources [1].clip = clips [1];
					audioSources [1].Play ();
				}
				break;
			case 2:
				if(opt.GetComponent<options>().highScore > 2000){
					opt.GetComponent<options> ().weapon = weapon;
					audioSources [0].clip = clips [0];
					audioSources [0].Play ();
					Instantiate(particles, this.transform.position, transform.rotation);
				}
				else{
					audioSources [1].clip = clips [1];
					audioSources [1].Play ();
				}
				break;
			case 3:
				if(opt.GetComponent<options>().highScore > 5000){
					opt.GetComponent<options> ().weapon = weapon;
					audioSources [0].clip = clips [0];
					audioSources [0].Play ();
					Instantiate(particles, this.transform.position, transform.rotation);
				}
				else{
					audioSources [1].clip = clips [1];
					audioSources [1].Play ();
				}
				break;
			case 4:
				if(opt.GetComponent<options>().highScore > 10000){
					opt.GetComponent<options> ().weapon = weapon;
					audioSources [0].clip = clips [0];
					audioSources [0].Play ();
					Instantiate(particles, this.transform.position, transform.rotation);
				}
				else{
					audioSources [1].clip = clips [1];
					audioSources [1].Play ();
				}
				break;
			default:
				audioSources [1].clip = clips [1];
				audioSources [1].Play ();	
				break;
			}


		} else {
			audioSources [1].clip = clips [1];
			audioSources [1].Play ();	
		}
		GameObject explain = GameObject.Find("explainText");
		explain.guiText.text = text;

		
	}
}