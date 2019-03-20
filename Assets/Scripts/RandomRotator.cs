//code used to add rotation to the obstecles
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	public float tumble;
	private Rigidbody rb;
	// variable to hold the max tumble value


	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
	

}
