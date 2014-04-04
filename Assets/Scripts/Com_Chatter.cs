using UnityEngine;
using System.Collections;

public class Com_Chatter : MonoBehaviour {
	public int rand;
	public int counter;
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

	
	// Use this for initialization
	void Start () {
		counter = 200;
		dialouge = new string[100];
		speaker = new int[100];
		used = new bool[100];
		for (int i = 0; i<100; i++){	
			used[i] = false;
		}

		dialouge = dialougeSet (dialouge);
		bird = GameObject.Find ("Bird");
		 hare = GameObject.Find ("Bob");
		 frog = GameObject.Find ("Froggerson");
		 eliza = GameObject.Find ("Eliza");
		 words = GameObject.Find ("WordsTalking");

		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0 && talking == false) {
			//GameObject terminal = GameObject.Find ("Terminal");
			//terminal.transform.position = new Vector3 (8, -.4f, 20);
			rand = Random.Range (0, 11);
			int i = 0;
			while (used[rand]==true){
				rand = Random.Range (0, 11);
				i++;
				if (i>=10){
					break;
				}
			}
						if (rand == 0) {
							start = 0;
							end = 3;
							used[0] = true;
						}
						else if (rand == 1) {
							start = 20;
							end = 23;
							used[1] = true;
						}
						else if (rand == 2) {
							start = 23;
							end = 24;
							used[2] = true;
						}
						else if (rand == 3) {
							start = 10;
							end = 14;
							used[3] = true;
						}
						else if (rand == 4) {
							start = 24;
							end = 26;
							used[4] = true;
							}
						else if (rand == 5) {
							start = 30;
							end = 37;
							used[5] = true;
						}
						else if (rand == 6){
							start = 38;
							end = 42;
							used[6] = true;
						}
						else if (rand == 7){
							start = 43;
							end = 47;
							used[7] = true;
						}
						else if (rand == 8){
							start = 47;
							end = 54;
							used[8] = true;
						}
						else if (rand == 9){
							start = 55;
							end = 66;
							used[9] = true;
						}
						else if (rand == 10){
							start = 67;
							end = 79;
							used[10] = true;
						}
			talking = true;
				}
		if (counter <= 0 && talking == true){
			words.transform.position = new Vector3 (.25f,.1f,0);
			words.guiText.text = dialouge[start];
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

			
			counter = 200;
			start++;
			if (start>end){ 
				counter = 800;
				talking = false;
				words.transform.position = new Vector3 (10,10,10);
				frog.transform.position = new Vector3 (11.6f, -.4f,-20);
				hare.transform.position = new Vector3 (11.6f, -.4f,-20);
				bird.transform.position = new Vector3 (11.6f, -.4f,-20);
				eliza.transform.position = new Vector3 (11.6f, -.4f,-20);
			}
		}

		counter--;
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
		yo[1] = "Hey Eliza you suck.";
		speaker[1] = 1;
		yo[2] = "Bird out";
		speaker[2] = 1;

		yo[10] = "That's a pretty nice ship Eliza.";
		speaker[10] = 2;
		yo[11] = "'Cause I'm the one who built it, that's what I was getting at.";
		speaker[11]=2;
		yo[12] = "See I'm useful! Right?";
		speaker[12]=2;
		yo[13] = "Right?";
		speaker[13] =2;

		yo [20] = "Bob here.";
		speaker[20] = 0;
		yo [21] = "Do a barrel roll!";
		speaker[21] = 0;
		yo [22] = "Keep trying, I'm sure some button does it.";
		speaker[22] = 0;

		yo [23] = "Press F2 to send an impassioned letter to your congressman.";
		speaker [23] = 0;

		yo [24] = "You know, it seems like just last week I was learning to be a proper lady on Earth.";
		speaker[24] = 3;
		yo [25] = "It's just kind of a change of pace is what I'm saying.";
		speaker[25] = 3;

		yo[30] = "Eliza help me!";
		speaker[30] = 2;
		yo[31] = "What's wrong?";
		speaker[31] = 3;
		yo[32] = "I need to move some furniture.";
		speaker[32] = 2;
		yo[33] = "Froggerson, I'm kind of fighting some aliens.";
		speaker[33] = 3;
		yo[34] = "Oh okay.";
		speaker[34] = 2;
		yo[35] = "You can still help though right?";
		speaker[35] = 2;
		yo[36] = "...";
		speaker[36] = 3;

		yo[38] = "Eliza help me! I'm under attck!";
		speaker[38] = 2;
		yo[39] = "I'll be right there! Where are you?";
		speaker[39] = 3;
		yo[40] = "About two hundred lightyears from you, I'll give you the coordinates.";
		speaker[40] = 2;
		yo[41] = "Godammit Froggerson.";
		speaker[41] = 3;

		yo [43] = "You're becoming more like your father Eliza.";
		speaker[43] = 0;
		yo [44] = "Aw, thanks Bob.";
		speaker[44] = 3;
		yo[45] = "Wait, how do you know my father? You're some kind of alien rabbit thing.";
		speaker[45] = 3;
		yo[46] = "Oh I don't. It just seemed like a nice thing to say.";
		speaker[46] = 0;

		yo[47] = "Oh noooooooo!";
		speaker[47] = 2;
		yo[48] = "Ahem, I said oh nooooooo!";
		speaker [48] = 2;
		yo[49] = "Hello? Isn't anyone going to help me?";
		speaker[49] = 2;
		yo[50] = "No.";
		speaker[50] = 3;
		yo[51] = "Nope.";
		speaker[51] = 1;
		yo[52] = "Nah.";
		speaker[52] = 0;
		yo[53] = "Oh come on!";
		speaker[53] = 2;

		yo[55] = "Froggerson this is Eliza, do you copy?";
		speaker[55] = 3;
		yo[56] = "Yup, I here you. What's wrong Eliza?";
		speaker[56] = 2;
		yo[57] = "I can't seem to speed up or slow down.";
		speaker[57] = 3;
		yo[58] = "I can only go left or right.";
		speaker[58] = 3;
		yo[59] = "Yeah. What's the problem.";
		speaker[59] = 2;
		yo[60] = "It's a spaceship, why can't I just move in any direction I want.";
		speaker[60] = 3;
		yo[61]  = "Oh. Well that just seemed like a lot of work so I didn't bother.";
		speaker[61] = 2;
		yo[62] = "Why are we working with this guy?";
		speaker[62] = 3;
		yo[63] = "We're a team Eliza, we have to stick together.";
		speaker[63] = 0;
		yo[64] = "Oh noooo! Help me Eliza!";
		speaker[64] = 2;
		yo[65] = "Ugh. Fine.";
		speaker[65] = 3;

		yo[67] = "So Bird, how's the family?";
		speaker[67] = 0;
		yo[68] = "Pretty good. The wife and I are thinking of having an egg pretty soon.";
		speaker[68] = 1;
		yo[69] = "Congratulations! And do soon after the wedding!";
		speaker[69] = 0;
		yo[70] = "Wait, what wedding.";
		speaker[70] = 3;
		yo[71] = "The one I had that you weren't invited to, what wedding did you think?";
		speaker[71] = 1;
		yo[72] = "I've saved your life like twenty times!";
		speaker[72] = 3;
		yo[73] = "I tried to get him to invite you Eliza.";
		speaker[73] = 0;
		yo[74] = "Oh sorry Eliza the invitite when I shoved it in the garbage.";
		speaker[74] = 1;
		yo[75] = "What's your problem Bird?";
		speaker[75] = 3;
		yo[76] = "He thinks you're his rival.";
		speaker[76] = 2;
		yo[77] = "You think I'm your rival?";
		speaker[77] = 3;
		yo[78] = "What? You didn't even... screw you Eliza.";
		speaker[78] = 1;
		
		return yo;
	}		



}



