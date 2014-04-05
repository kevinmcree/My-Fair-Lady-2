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
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

	}
	
	void Update ()
	{
		if (comboCounter<=0){
			combo = 0;
			UpdateCombo();
			comboCounter = 100;
		}
		comboCounter--;
		counter--;

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
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
				int rand = Random.Range (0, hazards.Length);
				if (rand==6 || rand==7 || rand==8){
					rand = Random.Range (0, hazards.Length);
				}
				GameObject hazard = hazards [rand];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			hazardCount++;
			spawnWait-=.01f;
				waveWait-=.1f;
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
		score += newScoreValue;
		UpdateScore ();
	}

	public void AddCombo (){
		combo++;
		comboCounter = 100;
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