using UnityEngine;
using System.Collections;
using System;

/*
Hello Kevin,
I am writing these comments largely for your benifit, though they are also usful for me, when you inevitably
open this file. The base code originates from your Com_Chatter script, but has been redone to work in the tutorial.
Instead of randomly selecting one of a series of phrases to print to the screen, it prints out
information in a specific order so as to give the player consistent and hopefully useful information.
I have also implemnted a system time tracking system to coordinate text to appear at times related to
spawn times of enemies.


*/
public class tutorial_dialog : MonoBehaviour {
	public  string[] dialouge;
	public int[] speaker;
	public int curDialogue;
	public bool talking;
	public GameObject bird;
	public GameObject hare;
	public GameObject frog;
	public GameObject eliza;
	public GameObject words;

	private DateTime talkTime;					//Keeps track of the time that any dialogue starts
	//private DateTime startTime;					//Keeps track of when this script begins, used to coordinate dialogue with appearance of other GameObjects
	private DateTime curTime;					//The current time
	private TimeSpan timeDif;					//Keeps track of the time elapsed, this variable is changed fairly often, but it is more effecient to initialize it here


	
	
	//Initializes all variables when the script begins
	void Start () {

		curDialogue = 0;
		//startTime = System.DateTime.Now;
		talkTime = System.DateTime.Now;

		dialouge = new string[20];
		speaker = new int[20];

		bird = GameObject.Find ("Bird");
		hare = GameObject.Find ("Bob");
		frog = GameObject.Find ("Froggerson");
		eliza = GameObject.Find ("Eliza");
		words = GameObject.Find ("WordsTalking");

		dialouge = dialougeSet (dialouge);
		
	}


	void Update () {
		curTime = System.DateTime.Now;
		talking = true;



			//Moves around the sprites who are talking, for the purposes of the tutorial, this should never change, but I am leaving the rest
			//of the code intact in case we decide to change this later
			//Kevin, for your reference, you will note that I have removed your variable "Counter" in favor of using the system clock
		if (talking == true && curDialogue < 20) {	
			if(talkTime.Second - curTime.Second >= 5)
				talkTime = System.DateTime.Now;

			words.guiText.text = dialouge [curDialogue];
			words.transform.position = new Vector3 (.20f,.13f,0);
			hare.transform.position = new Vector3 (-11.5f, -.4f, -7.4f);
			frog.transform.position = new Vector3 (-11.5f, -.4f, -20);
			bird.transform.position = new Vector3 (-11.5f, -.4f, -20);
			eliza.transform.position = new Vector3 (11.5f, -.4f, -20);
				
			timeDif = curTime - talkTime;
			//start++;


			if (timeDif.Seconds  <= 5) { 
				curDialogue++;
				talking = false;
				words.transform.position = new Vector3 (10, 10, 10);
				frog.transform.position = new Vector3 (11.6f, -.4f, -20);
				hare.transform.position = new Vector3 (11.6f, -.4f, -20);
				bird.transform.position = new Vector3 (11.6f, -.4f, -20);
				eliza.transform.position = new Vector3 (11.6f, -.4f, -20);
			}
		}
		else {
			words.transform.position = new Vector3 (10, 10, 10);
			frog.transform.position = new Vector3 (11.6f, -.4f, -20);
			hare.transform.position = new Vector3 (11.6f, -.4f, -20);
			bird.transform.position = new Vector3 (11.6f, -.4f, -20);
			eliza.transform.position = new Vector3 (-11.5f, -.4f, -7.4f);
		}
		
			
	}
	
	string[] dialougeSet(string[] yo){

		//Temporary Block, Fills all spaces in the array with a numeric value corresponding to their index.
		//Basically this ensures that each point in the array has a value
		for (int i = 0; i < 20; i++){
			yo[i] = i.ToString();
		}

		for (int i = 0; i < 20; i++){	// 0=hare, 1=bird, 2=frog, 3=Eliza
			speaker[i] = 0;
		}
		yo[0] = "Yo this is Bird.";
		speaker[0] = 1;
		yo[1] = "I thought that I would remind you that the  left and right arrow keys control movement";
		speaker[1] = 1;
		yo[2] = "Eliza! Quick! Push SPACE to shoot!";
		speaker[2] = 1;
		
		
		return yo;
	}		
	
	
	
}



