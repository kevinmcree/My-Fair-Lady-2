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
		for (int i = 0; i < 50; i++){
			yo[i] = i.ToString();
		}

		for (int i = 0; i < 50; i++){	// 0=hare, 1=bird, 2=frog, 3=Eliza
			speaker[i] = 0;
		}

		//Start blue

		yo[0] = "Eliza!  It's me, Hare.";
			speaker[0] = 0;
		yo[1] = "We're going to teach you how to fly your ship, alright?";
			speaker[1] = 0;
		yo[2] = "Who is 'we'?  Why are you speaking so slowly?";
			speaker[2] = 3;
		yo[3] = "'We' is your squad, Eliza.  Can you say my name?";
			speaker[3] = 2;
		yo[4] = "I'm Froggerson.";
			speaker[4] = 2;
		yo[5] = "I can understand you just fine.  Bird, please make them stop...";
			speaker[5] = 3;
		yo[6] = "Hey Eliza, stop being so stupid.";
			speaker[6] = 1;
		yo[7] = "Alright, that's it!";
			speaker[7] = 3;
		yo[8] = "As soon as I learn now to pilot this thing, I'm blasting you all out of the sky!";
			speaker[8] = 3;
		yo[9] = "Ahahaha!  Alright, alright, no need to get so touchy.";
			speaker[9] = 0;
		yo[10] = "Hey, let's get started!  Movement is really simple, just use the arrow keys to go from side to side.";
			speaker[10] = 2;
		yo[11] = "Not that you needed us to tell you, probably.";
			speaker[11] = 1;
		yo[12] = "And then, you use the spacebar to shoot!";
			speaker[11] = 2;
		yo[13] = "Spacebar, heheh~";
			speaker[13] = 0;
		yo[14] = "Simple enough, right?  We're sending a few drones your way, so try it out!";
			speaker[14] = 2;

		//blam blam blam

		yo[15] = "Good job.";
			speaker[15] = 1;
		yo[16] = "Woah, I feel like I could scoop up that sarcasm into a cup.";
			speaker[16] = 0;
		yo[17] = "Yes, yes, what next?  Why is my view tinted blue?";
			speaker[17] = 3;
		yo[18] = "Oh, right, the color system!!";
			speaker[18] = 2;
		yo[19] = "The color system?  What's that?";
			speaker[19] = 3;
		yo[20] = "Well, it's a little more like shifting dimensions, but the higher-ups wanted to keep it simple.";
			speaker[20] = 2;
		yo[21] = "Basically, there are 3 colors: Red, blue, and yellow.  You can change colors by pressing the up and down buttons!";
			speaker[21] = 2;
		yo[22] = "Okay…and?";
			speaker[22] = 3;
		yo[23] = "AND you can only hit and get hit by the enemy ships that match your color!";
			speaker[23] = 2;
		yo[24] = "Hmm…seems simple enough.  Let's give it a try!";
			speaker[24] = 3;
		yo[25] = "Let's see how badly you fail with this new wave, then.";
			speaker[25] = 1;
		yo[26] = "Bird!  Be nice!!";
			speaker[26] = 0;

		//blammoooooo red and yellow ships come in little waves

		yo[27] = "I think I'm getting the hang of this.";
			speaker[27] = 3;
		yo[28] = "Good!  See, it's not that complicated, right?";
			speaker[28] = 0;
		yo[29] = "I can't wait until she gets to the harder levels.";
			speaker[29] = 1;
		yo[30] = "Levels?  What?";
			speaker[30] = 3;
		yo[31] = "Nevermind.";
			speaker[31] = 1;
		yo[32] = "Oh yeah!  And by the way, we've got cool power-ups for you to use!";
			speaker[32] = 2;
		yo[33] = "Power-ups?  What are we, in a video game or somethi--";
			speaker[33] = 3;
		yo[34] = "Just press (whatever key you need to press) to activate it!  They can be any number of things.";
			speaker[34] = 2;
		yo[35] = "Because, y'know, I like things to be customizable.";
			speaker[35] = 2;
		yo[36] = "Sounds good to me, then, I'll be sure to try that out next time!";
			speaker[36] = 3;
		yo[37] = "Alright then, looks like you're ready to be sent out into the field!";
			speaker[37] = 0;
		yo[38] = "I bet you 5000 points she doesn't even last a minute.";
			speaker[38] = 1;
		yo[39] = "I bet you 10000 she doesn't last 30 seconds!";
			speaker[39] = 2;
		yo[40] = "Hey Eliza, crash for me, okay?  I need the money.";
			speaker[40] = 2;
		yo[41] = "Hey!  At least try to be a little supportive…!";
			speaker[41] = 0;
		yo[42] = "Oh dear...";
			speaker[42] = 3;
		
		//end of tutorial

		return yo;
	}		
}
