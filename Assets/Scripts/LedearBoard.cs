using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedearBoard : MonoBehaviour {
	public Text highScoreText;
	public string highScoreName;
	public InputField nameField;
	int [] highScoreValues;
	string[] highScoreNames;
	public int numOfScores;
	public GameObject newHighScore;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();

		highScoreValues = new int[numOfScores];
		for (int i = 0; i < highScoreValues.Length; i++) {
			try{
				highScoreValues [i] = PlayerPrefs.GetInt ("highScoreValue" + i);
			}catch(System.Exception e){
				highScoreValues [i] = 0;
			}
		}
		highScoreNames = new string[numOfScores];
		if(PlayerPrefs.GetString("highScoreName0") != ""){
			for (int i = 0; i < highScoreNames.Length; i++) {
				try{
					highScoreNames [i] = PlayerPrefs.GetString("highScoreName" + i);
				}catch(System.Exception e){
					highScoreNames [i] = "NANANA";
				}
			}
			// sets an intial name list for the scores (fill with funny names)
		}else{
			highScoreNames [0] = "RUBYR";
			highScoreNames [1] = "HARRYP";
			highScoreNames [2] = "FROPPY";
			highScoreNames [3] = "KAKASI";
			highScoreNames [4] = "LUCINA";
			highScoreNames [5] = "PETERP";
			highScoreNames [6] = "BRUCEW";
			highScoreNames [7] = "GOLLUM";
			highScoreNames [8] = "THORN";
			highScoreNames [9] = "ENDO";
		}

		highScoreText.text = "";
		newHighScore.SetActive (false);

	}

	public void saveScores(){
		for (int i = 0; i < numOfScores; i++) {
				PlayerPrefs.SetInt ("highScoreValue" + i, highScoreValues [i]);
			    PlayerPrefs.SetString ("highScoreName" + i,highScoreNames[i]);
			}
	}

	public void drawScores(){
		highScoreText.text = "";
		for(int i = 0; i < numOfScores; i++){
			
			//sets the name part to alawayes be 6 characters (space if half a charchter)
//			if (highScoreNames [i].Length > 6) {
//				highScoreNames [i].Substring (0, 6);
//			} else if (highScoreNames [i].Length < 6) {
//				int s = 6 - highScoreNames [i].Length; 
//				while (s>0) {
//					highScoreNames [i] = highScoreNames [i] + "  ";
//					s--;
//				}
//			}

			string startSpace;
			if (i < 9) {
				startSpace = "  ";
			} else {
			    startSpace = "";
			}
			highScoreText.text +=(i+1) + startSpace + ")  " + highScoreNames[i] + ": " + highScoreValues[i]+"\n";
		}
	}

	public void checkHighScore(int newScore){
		for(int i = 0; i < highScoreValues.Length; i++){

			if (newScore > highScoreValues [i]) {
				newHighScore.SetActive (true);
				drawScores ();
				nameField.onEndEdit.AddListener (delegate {enterName (i,newScore);});
				return;
//				for (int n = highScoreValues.Length - 1; n > i; n--) {
//					highScoreValues [n] = highScoreValues [n - 1];
//					highScoreValues [i] = newScore;
//					saveScores ();
//				}
			}
		}

		drawScores ();
	}

	void updateScore(int i,int newScore){
		for (int n = highScoreValues.Length - 1; n > i; n--) {
			highScoreValues [n] = highScoreValues [n - 1];
			highScoreNames [n] = highScoreNames [n - 1];
		}
		highScoreValues [i] = newScore;
		highScoreNames [i] = highScoreName;
		saveScores ();
		drawScores ();
	}

	void enterName(int i, int newScore){
		highScoreName = nameField.text;

		highScoreName = highScoreName.ToUpper();
		updateScore (i,newScore);
		newHighScore.SetActive (false);
	}

	public void resetScores(){
		for (int i = 0; i < numOfScores; i++) {
			PlayerPrefs.DeleteKey ("highScoreName" + i);
			PlayerPrefs.DeleteKey ("highScoreValue"+ i);
			Start ();

		}
	}

}
