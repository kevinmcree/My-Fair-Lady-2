using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public bool inStore;
	public int range;
	public bool isTutorial;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	public int score;
	public int counter;

	public int combo;
	public int comboCounter;
	GameObject comboText;
	public int scoreMultiplier;
	public int comboExtender;

	void Start ()
	{
		comboText = GameObject.Find ("Combo");
		gameOver = false;
		restart = false;
		inStore=false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		counter = 1000;
		comboExtender = 0;
		scoreMultiplier = 1;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

	}
	
	void Update (){
		if (comboCounter<=0){
			combo = 0;
			UpdateCombo();
			comboCounter = 100+comboExtender;
		}
		comboCounter--;
		counter--;

		if (comboCounter<=0){
			combo = 0;
			UpdateCombo();
			comboCounter = 100+comboExtender;
		}
		comboCounter--;
		counter--;

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel ("options select");
			}
		}

	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if(isTutorial)
					range = 6;
				int rand = Random.Range (0, range);
				if (rand==6 || rand==7 || rand==8 || rand==9 || rand==13 || rand==14 || rand==15){
					rand = Random.Range (0, range);
					if (rand==8 || rand==9 || rand==13 || rand==14 || rand==15){
						int otherRand = Random.Range (0, 2);
						if (otherRand!=1){
							rand = Random.Range (0, range);
						}
					}

				}
				if (rand == 9 || rand == 10 || rand == 11){
					int otherRand = Random.Range (0, 2);
					if (otherRand!=1){
						rand = Random.Range (0, range);
					}
				}
				GameObject hazard = hazards [rand];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			hazardCount+=2;
			spawnWait-=.03f;
			waveWait-=.2f;
			if (spawnWait<=0){
				spawnWait=0;
			}
			if (waveWait<=0){
				waveWait=0;
			}
			if (hazardCount==16 && !isTutorial){
				range+=5;
			}
			if (hazardCount==30 && !isTutorial){
				range+=3;
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue*scoreMultiplier;
		UpdateScore ();
	}

	public void AddCombo (){
		combo++;
		comboCounter = 100+comboExtender;
		UpdateCombo();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	void UpdateCombo (){
		comboText.guiText.text = combo.ToString();
	}

public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}