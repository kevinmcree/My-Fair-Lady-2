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

	//isBoss checks if the player is currently fighting the boss so that no additional enemies spawn
	//boss checks if the boss has already spawned this game
	public bool isBoss;
	public bool boss;

	public GUIText scoreText;

	private bool gameOver;
	private bool restart;
	public int score;
	public int counter;

	public int combo;
	public int comboCounter;
	public int scoreMultiplier;
	public int comboExtender;
	public AudioClip[] bossClip = new AudioClip[1];
	public AudioSource[] bossSource = new AudioSource[1];

	void Start ()
	{
		gameOver = false;
		restart = false;
		inStore=false;
		score = 0;
		counter = 1000;
		comboExtender = 0;
		scoreMultiplier = 1;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		isBoss = false;

		int i = 0;
		while (i < 1) {
			GameObject child = new GameObject("audio");
			child.transform.parent = gameObject.transform;
			bossSource[i] = child.AddComponent("AudioSource") as AudioSource;
			bossSource[i].volume=.99f;
			i++;
		}
		bossSource[0].clip = bossClip[0];

		
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
		if (Input.GetKeyDown("escape") && isTutorial){
			Application.LoadLevel("options select");
		}

		}
		
		IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{	if (boss == false){
			for (int i = 0; i < hazardCount; i++)
			{
				if(isTutorial)
					range = 5;
				int rand = Random.Range (0, range);
				if (rand==9 || rand==10 || rand==11 || rand==12 || rand==16 || rand==17 || rand==18 || rand==19 || rand==20 || rand==21){
					rand = Random.Range (0, range);
					if (rand==11 || rand==12 || rand==16 || rand==17 || rand==18 || rand==19 || rand==20 || rand==21){
						int otherRand = Random.Range (0, 2);
						if (otherRand!=1){
							rand = Random.Range (0, range);
						}
						if ( rand==19 || rand==20 || rand==21){
							rand = Random.Range (0, range);
							}

						}

				}
				if ( rand == 6 || rand == 7 || rand == 8 || rand == 13 || rand == 14 || rand == 15){
					int otherRand = Random.Range (0, 4);
					if (otherRand!=1){
						rand = Random.Range (0, range);
					}
				}
				
				if(isTutorial && rand > 5)
						rand = Random.Range(0,5);
				GameObject hazard = hazards [rand];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				if(!isBoss){
					if(rand == 22 && !boss){
						boss = true;
						isBoss = true;
						Instantiate (hazard, spawnPosition, spawnRotation);
					//	audio.Pause ();
					//	bossSource[0].Play ();
					}
					else{
						Instantiate (hazard, spawnPosition, spawnRotation);
					}
				}
				yield return new WaitForSeconds (spawnWait);
			}
			}
			if (inStore == false){
				hazardCount+=2;
				spawnWait-=.03f;
				waveWait-=.2f;
			}
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
			if (hazardCount==40 && !isTutorial){
				range+=3;
			}
			if (hazardCount==50 && !isTutorial){
				range+=1;
			}
			

			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue*scoreMultiplier;
		GameObject go = GameObject.Find("Player");
		if (go.GetComponent<Done_PlayerController>().shipType == 4){
			score=0;
		}
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
		GameObject comboText = GameObject.Find ("Combo");

		comboText.guiText.text = combo.ToString();
	}

public void GameOver ()
	{
		gameOver = true;
		Camera.main.transform.position = new Vector3(315.5f, 22.7f, -2);
		inStore = true;
		audio.Pause ();
		GameObject laser = GameObject.Find ("lightSaber");
		laser.transform.position = new Vector3 (1000,1000,1000);

	}
}