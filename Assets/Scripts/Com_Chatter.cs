using UnityEngine;
using System.Collections;

public class Com_Chatter : MonoBehaviour {
	public int rand;
	public int counter;
	public  string[] dialouge;
	public int[] speaker;
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
			rand = Random.Range (0, 9);
						if (rand == 0) {
								start = 0;
								end = 3;
						}
						else if (rand == 1) {
								start = 20;
								end = 23;
						}
						else if (rand == 2) {
								start = 23;
								end = 24;
						}
						else if (rand == 3) {
								start = 10;
								end = 14;
						}
						else if (rand == 4) {
							start = 24;
							end = 26;
						}
						else if (rand == 5) {
							start = 30;
							end = 37;
						}
						else if (rand == 6){
							start = 38;
							end = 42;
						}
						else if (rand == 7){
							start = 43;
							end = 47;
						}
						else if (rand == 8){
							start = 47;
							end = 55;
						}
			talking = true;
				}
		if (counter <= 0 && talking == true){
			words.transform.position = new Vector3 (.15f,.95f,0);
			words.guiText.text = dialouge[start];
			if( speaker[start]==0){
				hare.transform.position = new Vector3 (8, -.4f,13);
				frog.transform.position = new Vector3 (8, -.4f, 20);
				bird.transform.position = new Vector3 (8, -.4f, 20);
				eliza.transform.position = new Vector3 (8, -.4f, 20);
			}else if( speaker[start]==1){
				bird.transform.position = new Vector3 (8, -.4f,13);
				frog.transform.position = new Vector3 (8, -.4f, 20);
				hare.transform.position = new Vector3 (8, -.4f, 20);
				eliza.transform.position = new Vector3 (8, -.4f, 20);
			}else if( speaker[start]==2){
				frog.transform.position = new Vector3 (8, -.4f,13);
				hare.transform.position = new Vector3 (8, -.4f, 20);
				bird.transform.position = new Vector3 (8, -.4f, 20);
				eliza.transform.position = new Vector3 (8, -.4f, 20);
			}else if( speaker[start]==3){
				frog.transform.position = new Vector3 (8, -.4f,20);
				hare.transform.position = new Vector3 (8, -.4f, 20);
				bird.transform.position = new Vector3 (8, -.4f, 20);
				eliza.transform.position = new Vector3 (8, -.4f, 13);
			}

			
			counter = 150;
			start++;
			if (start>end){ 
				counter = 800;
				talking = false;
				words.transform.position = new Vector3 (10,10,10);
				frog.transform.position = new Vector3 (8, -.4f, 20);
				hare.transform.position = new Vector3 (8, -.4f, 20);
				bird.transform.position = new Vector3 (8, -.4f, 20);
				eliza.transform.position = new Vector3 (8, -.4f, 20);
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
		yo[50] = "Hello? Isn't anyone going to help me?";
		speaker[50] = 2;
		yo[51] = "No.";
		speaker[51] = 3;
		yo[52] = "Nope.";
		speaker[52] = 1;
		yo[53] = "Nah.";
		speaker[53] = 0;
		yo[54] = "Oh come on!";
		speaker[54] = 2;

		
		
		return yo;
	}		



}



