//This is the game controller it handeles the game opration such as enemy spawning, gameover, updating and displaying the score, 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText, restartText, gameOverText;
	public GameObject restartButton;
	private int score;
	private bool gameOver, restart;
	public int waveCount;
	public float waveSpeedFactor;
	public GameObject scoreBoard;
	public LedearBoard lb;
	public GameObject pauseArea;

	private void Awake()
	{
		//Set screen size for Standalone
		#if UNITY_STANDALONE
		Screen.SetResolution(600, 900, false);
		Screen.fullScreen = false;
		#endif



	}

	void Start()
	{

		StartCoroutine(SpawnWaves ());
		score = 0;
		waveCount = 1;
		UpdateScore ();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		restartButton.SetActive (false);
		scoreBoard.SetActive (false);

	}

	void Update(){
		
		// restrting the game using the r key (bugs out with the score bored name input so temperarliy removed)
//		if (restart){
//		 	if (Input.GetKeyDown (KeyCode.R)){
//				RestartGame();
//			}
//		}

	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		int waveHazards;
		while(!gameOver)
		{
			waveHazards = Random.Range (hazardCount, hazardCount + waveCount - 1);
			for(int i = 0; i < waveHazards; i++){
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spwnPosition = new Vector3 (Random.Range(-6, 6), 0, spawnValues.z);
				Quaternion spwnRotation = Quaternion.identity;
				Instantiate (hazard, spwnPosition, spwnRotation);	
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (!gameOver) {
				UpdateWave ();
			}
		}

	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();	
	}

	public void UpdateWave()
	{
		waveCount++;
		UpdateScore ();
	}

	void UpdateScore()
	{
		if (gameOver != true) {
			scoreText.text = "Score: " + score + "\nWave: " + waveCount;
		}
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over\n" + scoreText.text;
		gameOver = true;
		scoreText.text = "";
		restartText.text = "Push to Restart";
		restart = true;
		restartButton.SetActive (true);

		lb.checkHighScore (score); 
		scoreBoard.SetActive (true);

		pauseArea.SetActive (false);

	}

	public void RestartGame(){
		SceneManager.LoadScene ("main");
	}

	public void quitGame(){
		Application.Quit();
	}
}
