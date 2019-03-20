//script controlling the downward movement of enemys and obsticles, the range of enemy movment speed increses as the player progresses through enemy waves
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private GameControler gameControlerScript;

	void Start () {
		float enemySpeedBoost;
		
		GameObject gameControlerObject = GameObject.FindWithTag ("GameController");
		if(gameControlerObject == null){
			Debug.Log ("coludent find game  controller");
		}
		gameControlerScript = gameControlerObject.GetComponent<GameControler> ();
		if(gameControlerScript == null){
			Debug.Log ("coludent find game script controler");
		}
		rb = GetComponent<Rigidbody>();
		if(CompareTag("Enemy")){
			enemySpeedBoost = Random.Range(0 , (gameControlerScript.waveCount - 1) ) * gameControlerScript.waveSpeedFactor;
		}
		else{
				enemySpeedBoost = 0;			
		}

		rb.velocity = transform.forward * (speed - enemySpeedBoost);

	}
	

}
