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
		dialouge = new string[200];
		speaker = new int[200];
		used = new bool[200];
		for (int i = 0; i<200; i++){	
			used[i] = false;
		}

		dialouge = dialougeSet (dialouge);
		bird = GameObject.Find ("Bird");
		 hare = GameObject.Find ("Hare");
		 frog = GameObject.Find ("Froggerson");
		 eliza = GameObject.Find ("Eliza");
		 words = GameObject.Find ("WordsTalking");

		
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("Game Controller");
		if (	go.GetComponent<Done_GameController>().inStore==false){
		if (talking == true){
			words.transform.position = new Vector3 (.20f,.13f,0);
		}else{
			words.transform.position = new Vector3 (10,10,10);
		}
		if (counter <= 0 && talking == false) {
			//GameObject terminal = GameObject.Find ("Terminal");
			//terminal.transform.position = new Vector3 (8, -.4f, 20);
			rand = Random.Range (0, 17);
			int i = 0;
			while (used[rand]==true){
				rand = Random.Range (0, 17);
				i++;
				if (i>=16){
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
						else if (rand == 11){
							start = 79;
							end = 84;
							used[11] = true;
						}
						else if (rand == 12){
							start = 84;
							end = 88;
							used[12] = true;
						}
						else if (rand == 13){
							start = 89;
							end = 96;
							used[13] = true;
						}
						else if (rand == 14){
							start = 3;
							end = 10;
							used[14] = true;
						}
						else if (rand == 15){
							start = 96;
							end = 104;
							used[15] = true;
						}
						else if (rand == 16){
							start = 104;
							end = 111;
							used[16] = true;
						}
				talking = true;
				}
		if (counter <= 0 && talking == true){
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

			
			counter = 300;
			start++;
			if (start>end){ 
				counter = 700;
				talking = false;
				words.transform.position = new Vector3 (10,10,10);
				frog.transform.position = new Vector3 (11.6f, -.4f,-20);
				hare.transform.position = new Vector3 (11.6f, -.4f,-20);
				bird.transform.position = new Vector3 (11.6f, -.4f,-20);
				eliza.transform.position = new Vector3 (11.6f, -.4f,-20);
			}
		}

		counter--;
	} else {
		words.transform.position = new Vector3 (10,10,10);
	}
	}

	string[] dialougeSet(string[] yo){
		for (int i = 0; i<200; i++){
			yo[i] = i.ToString();
		}
		for (int i = 0; i<200; i++){	// 0=hare, 1=bird, 2=frog, 3=Eliza
			speaker[i] = 0;
		}
		yo[0] = "Yo, this is Bird.";
		speaker[0] = 1;
		yo[1] = "Hey Eliza, you suck.";
		speaker[1] = 1;
		yo[2] = "Bird out.";
		speaker[2] = 1;
		
		yo[3] = "So, why did they get you to build these ships, Froggerson?";
		speaker[3] = 3;
		yo[4] = "He offered to do it for free for the 'experience'.";
		speaker[4] = 1;
		yo[5] = "Hey, you've got to build a resume somehow.";
		speaker[5] = 2;
		yo[6] = "But you still haven't paid me back my money!";
		speaker[6] = 1;
		yo[7] = "He owes you money?";
		speaker[7] = 3;
		yo[8] = "Yeah, because the idiot didn't even get the force to cover the materials cost.";
		speaker[8] = 1;
		yo[9] = "Aw c'mon guys, don't focus on that. Think of the cool spaceships. Spaceships!";
		speaker[9] = 2;
		
		yo[10] = "That's a pretty nice ship, Eliza.";
		speaker[10] = 2;
		yo[11] = "'Cause I'm the one who built it, that's what I was getting at.";
		speaker[11]=2;
		yo[12] = "See, I'm useful! Right?";
		speaker[12]=2;
		yo[13] = "...Right?";
		speaker[13] =2;
		
		
		
		yo [20] = "Hare here!";
		speaker[20] = 0;
		yo [21] = "Do a barrel roll!";
		speaker[21] = 0;
		yo [22] = "Keep trying, I'm sure some button does it.";
		speaker[22] = 0;
		
		yo [23] = "Press F2 to send an impassioned letter to your congressman.";
		speaker [23] = 0;
		
		yo [24] = "You know, it seems like just last week I was learning to be a proper lady on Earth.";
		speaker[24] = 3;
		yo [25] = "It's just a change of pace, is what I'm saying.";
		speaker[25] = 3;
		
		
		yo[30] = "Eliza, help me!";
		speaker[30] = 2;
		yo[31] = "What's wrong!?";
		speaker[31] = 3;
		yo[32] = "I need to move some furniture.";
		speaker[32] = 2;
		yo[33] = "Froggerson, I'm kind of fighting some aliens right now...";
		speaker[33] = 3;
		yo[34] = "Oh, okay.";
		speaker[34] = 2;
		yo[35] = "…You can still help though, right?";
		speaker[35] = 2;
		yo[36] = "...";
		speaker[36] = 3;
		
		yo[38] = "Eliza, help me! I'm under attack!";
		speaker[38] = 2;
		yo[39] = "I'll be right there! Where are you?";
		speaker[39] = 3;
		yo[40] = "About two hundred lightyears from you, I'll give you the coordinates.";
		speaker[40] = 2;
		yo[41] = "God dammit Froggerson.";
		speaker[41] = 3;
		
		yo [43] = "You're becoming more like your father, Eliza.";
		speaker[43] = 0;
		yo [44] = "Aw, thanks Hare.";
		speaker[44] = 3;
		yo[45] = "Wait, how do you know my father? You're some kind of alien rabbit thing.";
		speaker[45] = 3;
		yo[46] = "Oh, I don't. It just seemed like a nice thing to say~!";
		speaker[46] = 0;
		
		yo[47] = "Oh noooooooo!";
		speaker[47] = 2;
		yo[48] = "…Ahem, I said: Oh nooooooo!!!";
		speaker [48] = 2;
		yo[49] = "Hello? Isn't anyone going to help me!?";
		speaker[49] = 2;
		yo[50] = "No.";
		speaker[50] = 3;
		yo[51] = "Nah.";
		speaker[51] = 1;
		yo[52] = "Nope.";
		speaker[52] = 0;
		yo[53] = "Oh, come on!";
		speaker[53] = 2;
		
		yo[55] = "Froggerson, this is Eliza, do you copy?";
		speaker[55] = 3;
		yo[56] = "Yup, I hear you. What's wrong, Eliza?";
		speaker[56] = 2;
		yo[57] = "I can't seem to speed up or slow down.";
		speaker[57] = 3;
		yo[58] = "In fact, I can only go left or right.";
		speaker[58] = 3;
		yo[59] = "Yeah?  What's the problem?";
		speaker[59] = 2;
		yo[60] = "It's a spaceship, why can't I just move in any direction I want?";
		speaker[60] = 3;
		yo[61]  = "Oh… Well, that just seemed like a lot of work so I didn't bother.";
		speaker[61] = 2;
		yo[62] = "Why are we working with this guy?";
		speaker[62] = 3;
		yo[63] = "We're a team, Eliza, we have to stick together.";
		speaker[63] = 0;
		yo[64] = "Oh noooo! Help me Eliza!";
		speaker[64] = 2;
		yo[65] = "Ugh. Fine...";
		speaker[65] = 3;
		
		yo[67] = "So Bird, how's the family?";
		speaker[67] = 0;
		yo[68] = "Pretty good. The wife and I are thinking of having an egg pretty soon.";
		speaker[68] = 1;
		yo[69] = "Congratulations! And so soon after the wedding!";
		speaker[69] = 0;
		yo[70] = "Wait, what wedding?";
		speaker[70] = 3;
		yo[71] = "The one I had that you weren't invited to, what wedding did you think?";
		speaker[71] = 1;
		yo[72] = "I've saved your life like twenty times!";
		speaker[72] = 3;
		yo[73] = "I tried to get him to invite you, Eliza.";
		speaker[73] = 0;
		yo[74] = "Sorry Eliza, I lost the invite when I threw it in the garbage.";
		speaker[74] = 1;
		yo[75] = "What's your problem, Bird?";
		speaker[75] = 3;
		yo[76] = "He thinks you're his rival.";
		speaker[76] = 2;
		yo[77] = "You think I'm your rival?";
		speaker[77] = 3;
		yo[78] = "What? You didn't even... screw you Eliza.";
		speaker[78] = 1;
		
		yo[79] = "Eliza, if you hit one of those floating teleporters you can upgrade your ship.";
		speaker[79] = 0;
		yo[80] = "Ah, alright.  But why is this stuff just floating around?";
		speaker[80] = 3;
		yo[81] = "Hey, it's not my fault the cargo eject button looks so much like the smoothie machine.";
		speaker[81] = 2;
		yo[82] = "You have a smoothie machine?";
		speaker[82] = 1;
		yo[83] = "Er... going through asteroids, channel breaking up!";
		speaker[83] = 2;
		
		yo[84] = "...I don't know, it's pretty big.";
		speaker[84] = 2;
		yo[85] = "I'm not a doctor, but as long as it's not discolored you should be fine.";
		speaker[85] = 0;
		yo[86] = "But it's all sticky and full of pus.";
		speaker[86] = 2;
		yo[87] = "Hey, get off my com line!";
		speaker[87] = 3;
		
		yo[88] = "Nice shot, Hare.";
		speaker[88] = 1;
		yo[89] = "Thanks Bird!";
		speaker[89] = 0;
		yo[90] = "I got one!";
		speaker[90] = 2;
		yo[91] = "Great job Froggerson!";
		speaker[91] = 0;
		yo[92] = "Ahem.";
		speaker[92] = 3;
		yo[93] = "Huh, sure is a lot of static coming through this channel. Almost sounds like whining.";
		speaker[93] = 1;
		yo[94] = "Oh, come on!";
		speaker[94] = 3;
		yo[95] = "Yup, definitely sounds like whining.";
		speaker[95] = 1;
		
		
		yo[96] = "Great shot Eliza!";
		speaker[96] = 0;
		yo[97] = "Thanks, Hare.";
		speaker[97] = 3; 
		yo[98] = "Move left or right to dodge bullets!";
		speaker[98] = 0;
		yo[99] = "I know, Hare.";
		speaker[99] = 3;
		yo[100] = "You can only hit or be hit by enemies of the same color as you!";
		speaker[100] = 0;
		yo[101] = "I KNOW, Hare!";
		speaker[101] = 3;
		yo[102] = "Gosh, I was only trying to help...";
		speaker[102] = 0;
		yo[103] = " *Sigh* I know, Hare.";
		speaker[103] = 3;
		
		yo[104] = "...I just think it's a nice color.";
		speaker[104] = 1;
		yo[105] = "Well, it sure is... different.";
		speaker[105] = 0;
		yo[106] = "I just don't want to ask Froggerson to do it until Eliza joins a different squad.";
		speaker[106] = 1;
		yo[107] = "Oh come now, she won't make fun of you.";
		speaker[107] = 0;
		yo[108] = "Yeah right, if she sees me flying in a bright pink ship of course she'd--";
		speaker[108] = 1;
		yo[109] = "What are you guys talking about?";
		speaker[109] = 3;
		yo[110] = "Change frequencies! Change frequencies!";
		speaker[110] = 1;
		
		yo[111] = "Hello my baby, hello my honey!";
		speaker[111] = 2;
		yo[112] = "Hello my ragtime gaaaaal~";
		speaker[112] = 2;
		yo[113] = "Send me a kiss by wire, baby my heart's on fire!";
		speaker[113] = 2;
		yo[114] = "No.";
		speaker[114] = 3;


		return yo;
	}		
}
