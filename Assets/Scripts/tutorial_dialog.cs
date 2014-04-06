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
	public bool[] used;
	public int start;
	public int end;
	public bool talking;
	GameObject bird;
	GameObject hare;
	GameObject frog;
	GameObject eliza;
	GameObject words;
	private DateTime talkTime;					//Keeps track of the time that any dialogue starts
	private DateTime startTime;					//Keeps track of when this script begins, used to coordinate dialogue with appearance of other GameObjects
	private DateTime curTime;					//The current time
	private TimeSpan timeDif;					//Keeps track of the time elapsed, this variable is changed fairly often, but it is more effecient to initialize it here


	
	
	//Initializes all variables when the script begins
	void Start () {
		start = 0;
		end = 20;
		startTime = System.DateTime.Now;

		dialouge = new string[20];
		speaker = new int[20];
		used = new bool[20];
		for (int i = 0; i<20; i++){	
			used[i] = false;
		}

		//Used to represent who is talking
		dialouge = dialougeSet (dialouge);
	
		
		
		
	}

	void Update () {
		curTime = System.DateTime.Now;
		GameObject go = GameObject.Find("Game Controller");

		//If a character is marked as talking, this segment moves the text to a place on screen where it is visible
		//otherwise the text object is moved off screen
			if (talking == true){
				//words.transform.position = new Vector3 (.20f,.13f,0);
			}else{
				//words.transform.position = new Vector3 (10,10,10);
			}
			if (talking == false) {
				int i = 0;
				talking = true;
			}

			//Moves around the sprites who are talking, for the purposes of the tutorial, this should never change, but I am leaving the rest
			//of the code intact in case we decide to change this later
			//Kevin, for your reference, you will note that I have removed your variable "Counter" in favor of using the system clock
		if (talking == true){	bird = GameObject.Find ("Bird");
			hare = GameObject.Find ("Bob");
			frog = GameObject.Find ("Froggerson");
			eliza = GameObject.Find ("Eliza");
			words = GameObject.Find ("i");

				talkTime = System.DateTime.Now;
				//words.guiText.text = dialouge[start];
				if( speaker[start]==0){
					hare.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
					frog.transform.position = new Vector3 (-11.5f, -.4f,-20);
					bird.transform.position = new Vector3 (-11.5f, -.4f,-20);
					eliza.transform.position = new Vector3 (11.5f, -.4f,-20);
				}else if( speaker[start]==1){
					bird.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
					frog.transform.position = new Vector3 (11.5f, -.4f,-20);
					hare.transform.position = new Vector3 (11.5f, -.4f,-20);
					eliza.transform.position = new Vector3 (11.5f, -.4f,-20);
				}else if( speaker[start]==2){
					frog.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
					hare.transform.position = new Vector3 (11.5f, -.4f,-20);
					bird.transform.position = new Vector3 (11.5f, -.4f,-200);
					eliza.transform.position = new Vector3 (11.6f, -.4f,-20);
				}else if( speaker[start]==3){
					frog.transform.position = new Vector3 (11.6f, -.4f,-20);
					hare.transform.position = new Vector3 (11.6f, -.4f,-20);
					bird.transform.position = new Vector3 (11.6f, -.4f,-200);
					eliza.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
				}
				
				timeDif = curTime - talkTime;
				//start++;


				if (timeDif.Seconds >= 15){ 
					talking = false;
					//words.transform.position = new Vector3 (10,10,10);
					frog.transform.position = new Vector3 (11.6f, -.4f,-20);
					hare.transform.position = new Vector3 (11.6f, -.4f,-20);
					bird.transform.position = new Vector3 (11.6f, -.4f,-20);
					eliza.transform.position = new Vector3 (11.6f, -.4f,-20);
				}
			}
			
	}
	
	string[] dialougeSet(string[] yo){
		for (int i = 0; i<100; i++){
			yo[i] = i.ToString();
		}
		for (int i = 0; i<100; i++){	// 0=hare, 1=bird, 2=frog, 3=Eliza
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



