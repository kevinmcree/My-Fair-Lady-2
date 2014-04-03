using UnityEngine;
using System.Collections;

public class Com_Chatter : MonoBehaviour {
	public int rand;
	public int counter;
	public  string[] dialouge;
	public int start;
	public int end;
	public bool talking;

	// Use this for initialization
	void Start () {
		counter = 200;
		dialouge = new string[100];
		dialouge = dialougeSet (dialouge);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0 && talking == false) {
					rand = Random.Range (0, 3);
						if (rand == 0) {
								GameObject bird = GameObject.Find ("Bird");
								bird.transform.position = new Vector3 (8, -.4f, 13);
								start = 0;
								end = 3;
								talking = true;
						}
						else if (rand == 1) {
								GameObject hare = GameObject.Find ("Bob");
								hare.transform.position = new Vector3 (8, -.4f, 13);
								start = 20;
								end = 23;
								talking = true;
						}
						else if (rand == 2) {
								GameObject frog = GameObject.Find ("Froggerson");
								frog.transform.position = new Vector3 (8, -.4f, 13);
								start = 10;
								end = 13;
								talking = true;
						}
						else {
						}	
				}
		if (counter <= 0 && talking == true){
			GameObject words = GameObject.Find ("WordsTalking");
			words.transform.position = new Vector3 (.25f,.95f,0);
			words.guiText.text = dialouge[start];
			counter = 200;
			start++;
			if (start>end){ 
				counter = 800;
				talking = false;
				words.transform.position = new Vector3 (10,10,10);
				GameObject bird = GameObject.Find ("Bird");
				GameObject hare = GameObject.Find ("Bob");
				GameObject frog = GameObject.Find ("Froggerson");
				GameObject terminal = GameObject.Find ("Terminal");
				terminal.transform.position = new Vector3 (8, -.4f, 13);
				frog.transform.position = new Vector3 (8, -.4f, 20);
				hare.transform.position = new Vector3 (8, -.4f, 20);
				bird.transform.position = new Vector3 (8, -.4f, 20);

			}
		}

		counter--;
	}

	string[] dialougeSet(string[] yo){
		for (int i = 0; i<100; i++){
			yo[i] = i.ToString();
		}
			yo[0] = "Yo this is Bird.";
			yo[1] = "This is a test of the dialouge system.";
			yo[2] = "Wassup";
			yo[10] = "Froggerson coming in.";
			yo[11] = "Oh nooooooooo!";
			yo[12] = "This is the end of the test.";
		yo [20] = "Bob here.";
		yo [21] = "Do a barrel roll!";
		yo [22] = "Over and out.";

			
		return yo;
	}		



}



