using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameControler gameControler;

	void Start()
	{
		GameObject gameControlerObject = GameObject.FindWithTag ("GameController");
		if (gameControlerObject != null) {
			gameControler = gameControlerObject.GetComponent<GameControler> ();
		}
		else
		{
			Debug.Log ("Can not find 'GameController' object");
		}	
	}

	void OnTriggerEnter(Collider other) {


		if (other.CompareTag("Boundry") || other.CompareTag("Enemy"))	return;
		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}
		if (other.CompareTag("Player")) 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameControler.GameOver ();
		}

		Destroy(other.gameObject);
		Destroy(gameObject);

		if (other.CompareTag("Weapon")) 
		{
			gameControler.AddScore (scoreValue);
		}


		
	}
}
