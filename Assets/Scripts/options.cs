using UnityEngine;
using System.Collections;

public class options : MonoBehaviour {
	public int shipType;
	public int weapon;
	public int playerModifier;
	//The high Score for the current play session
	public int highScore;
	// Use this for initialization

	//Initializes high score to the current score, if the Game Controller does not exist, it initializes to 0
	void Start () {
		GameObject cont = GameObject.Find ("Game Controller");
		if (cont == null)
			highScore = 0;
		else {
			highScore = cont.GetComponent<Done_GameController> ().score;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject cont = GameObject.Find ("Game Controller");
		if(cont != null){
			if(cont.GetComponent<Done_GameController> ().score > highScore)
				highScore = cont.GetComponent<Done_GameController> ().score;
		}
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
