using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject EnemyShot;
	private AudioSource shotSound;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	void Start () {
		shotSound = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}
	


	void Fire()
	{
		Instantiate (EnemyShot, shotSpawn.position , shotSpawn.rotation);
		shotSound.Play ();
	}
}
