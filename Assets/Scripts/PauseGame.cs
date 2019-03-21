using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public GameObject pauseMenu;
	private bool pause;

	// Use this for initialization
	void Start () {
		pause = false;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			pause = !pause;
		}
		if(pause){
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
		} else {
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
		}
		
	}

	public void setPasue(bool flag){
		pause = flag;
	}
}
