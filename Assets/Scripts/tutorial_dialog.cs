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
	public GameObject[] stuff;
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
	private DateTime curTime;					//The current time
	private TimeSpan timeDif;					//Keeps track of the time elapsed, this variable is changed fairly often, but it is more effecient to initialize it here


	//I thought it would make the scripting much easier to see it I spawned enemies directly from here as they are mentioned in the dialogue. This variable keeps track of which enemies are
	//currently spawning
	public int spawns;
	private DateTime lastSpawn;
	private TimeSpan spawnWait;
	public Vector3 spawnValues;


	
	
	//Initializes all variables when the script begins
	void Start () {

		curDialogue = 0;
		talkTime = System.DateTime.Now;
		spawns = 0;

		dialouge = new string[50];
		speaker = new int[50];

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
		Debug.Log ("Spam!\n");


			//Moves around the sprites who are talking, for the purposes of the tutorial, this should never change, but I am leaving the rest
			//of the code intact in case we decide to change this later
			//Kevin, for your reference, you will note that I have removed your variable "Counter" in favor of using the system clock
		if (talking == true && curDialogue < 45) {
			Debug.Log("talking\n");
			if(talkTime.Second - curTime.Second >= 5){
				talkTime = System.DateTime.Now;
				Debug.Log("Time Updated\n");
			}
			Debug.Log("Words Being Moved to Screen\n");
			words.guiText.text = dialouge [curDialogue];
			if( speaker[curDialogue]==0){
				hare.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
				frog.transform.position = new Vector3 (-11.5f, -.4f,-20);
				bird.transform.position = new Vector3 (-11.5f, -.4f,-20);
				eliza.transform.position = new Vector3 (11.5f, -.4f,-20);
			}else if( speaker[curDialogue]==1){
				bird.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
				frog.transform.position = new Vector3 (11.5f, -.4f,-20);
				hare.transform.position = new Vector3 (11.5f, -.4f,-20);
				eliza.transform.position = new Vector3 (11.5f, -.4f,-20);
			}else if( speaker[curDialogue]==2){
				frog.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
				hare.transform.position = new Vector3 (11.5f, -.4f,-20);
				bird.transform.position = new Vector3 (11.5f, -.4f,-200);
				eliza.transform.position = new Vector3 (11.6f, -.4f,-20);
			}else if( speaker[curDialogue]==3){
				frog.transform.position = new Vector3 (11.6f, -.4f,-20);
				hare.transform.position = new Vector3 (11.6f, -.4f,-20);
				bird.transform.position = new Vector3 (11.6f, -.4f,-200);
				eliza.transform.position = new Vector3 (-11.5f, -.4f,-7.4f);
			}
			Debug.Log("Words Initialized\n");
			words.transform.position = new Vector3 (.20f,.13f,0);
			//hare.transform.position = new Vector3 (-11.5f, -.4f, -7.4f);
			//frog.transform.position = new Vector3 (-11.5f, -.4f, -20);
			//bird.transform.position = new Vector3 (-11.5f, -.4f, -20);
			//eliza.transform.position = new Vector3 (11.5f, -.4f, -20);
				
			timeDif = curTime - talkTime;


			if (timeDif.Seconds  >= 5) { 
				talkTime = System.DateTime.Now;
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

		//If the conversation has reached a certain point change which enemies spawn
		if (curDialogue == 14){
			spawns = 1;
			lastSpawn = System.DateTime.Now;
		}
		if (curDialogue == 26)
				spawns = 2;

		//Spawns enemies every 3 seconds, the type depends on how long the tutorial has been going on
		spawnWait = curTime - lastSpawn;
		if(spawns == 1 && spawnWait.Seconds >= 3){
			Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (stuff[0], spawnPosition, spawnRotation);
			lastSpawn = System.DateTime.Now;
		}
		if(spawns == 2 && spawnWait.Seconds >= 3){
			Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			int choosenEnemy = UnityEngine.Random.Range(0,2);
			GameObject thing = stuff[choosenEnemy];
			Instantiate (thing, spawnPosition, spawnRotation);
			lastSpawn = System.DateTime.Now;
		}

		//Once the dialogue has ended, load the main game
		if(curDialogue >=43)
			Application.LoadLevel ("options select");

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
		yo[3] = "'We' as in your squad, Eliza.  Can you say my name?";
			speaker[3] = 2;
		yo[4] = "It's Froggerson. Frooogeeersooon.";
			speaker[4] = 2;
		yo[5] = "I can understand you just fine.  Bird, please make them stop...";
			speaker[5] = 3;
		yo[6] = "Eliza, stop being such an idiot.";
			speaker[6] = 1;
		yo[7] = "Alright, that's it!";
			speaker[7] = 3;
		yo[8] = "As soon as I learn now to pilot this thing, I'm blasting you all out of the sky!";
			speaker[8] = 3;
		yo[9] = "Ahahaha!  Alright, alright, no need to get so touchy.";
			speaker[9] = 0;
		yo[10] = "Movement is really simple, just use the arrow keys to go from side to side.";
			speaker[10] = 2;
		yo[11] = "Not that you needed us to tell you, probably.";
			speaker[11] = 1;
		yo[12] = "And you use the spacebar to shoot! Get it? Spacebar?";
			speaker[11] = 2;
		yo[13] = "I'd feel a lot more comfortable if your didn't design our ships based on puns.";
			speaker[13] = 3;
		yo[14] = "Simple enough, right?  We're sending a few drones your way, so try it out!";
			speaker[14] = 2;

		//blam blam blam

		yo[15] = "Good job.";
			speaker[15] = 1;
		yo[16] = "Woah, I feel like I could scoop up that sarcasm into a cup.";
			speaker[16] = 0;
		yo[17] = "Yes, yes, what's next?  Why is my view tinted blue?";
			speaker[17] = 3;
		yo[18] = "Oh, right, the color system!!";
			speaker[18] = 2;
		yo[19] = "The color system?  What's that?";
			speaker[19] = 3;
		yo[20] = "Well, it's a little more like shifting dimensions.";
			speaker[20] = 2;
		yo[21] = "Basically, there are 3 colors: Red, blue, and yellow";
			speaker[21] = 2;
		yo[22] = "You can change colors by pressing the up and down buttons!";
			speaker[22] = 2;
		yo[23] = "And you can only hit and get hit by the enemy ships that match your color!";
			speaker[23] = 2;
		yo[24] = "Hmm... seems simple enough.  Let's give it a try!";
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
		yo[32] = "Oh yeah!  And by the way, that number on the left is the combo meter";
			speaker[32] = 2;
		yo[33] = "Combo meter?  What are we, in a video game or somethi--";
			speaker[33] = 3;
		yo[34] = "The more enemies you shoot in a row the higher it gets.";
			speaker[34] = 2;
		yo[35] = "And the higher it gets the higher your score.";
			speaker[35] = 2;
		yo[36] = "Okay this is really starting to sound like some kind of...";
			speaker[36] = 3;
		yo[37] = "Alright then, looks like you're ready to be sent out into the field!";
			speaker[37] = 0;
		yo[38] = "I bet you 5000 points she doesn't even last a minute.";
			speaker[38] = 1;
		yo[39] = "I bet you 10000 she doesn't last 30 seconds!";
			speaker[39] = 2;
		yo[40] = "Hey Eliza, crash for me, okay?  I need the money.";
			speaker[40] = 2;
		yo[41] = "Hey!  At least try to be a little supportive!";
			speaker[41] = 0;
		yo[42] = "Oh dear...";
			speaker[42] = 3;
		
		//end of tutorial

		return yo;
	}		
}
