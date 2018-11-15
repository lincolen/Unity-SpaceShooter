using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaisiveManuver : MonoBehaviour {
	public float  dodge, smoothing, tilt;
	public Vector2 startWait, manuverTime, manuverWait;
	private float targetManuver;
	private Rigidbody rb;
	private float currentSpeed;
	public Boundry boundry;
	private Mover mover;

	void Start () {

		rb = GetComponent<Rigidbody> ();
		mover = GetComponent<Mover> ();
		//currentSpeed = mover.speed;
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ());


	}
	

	void FixedUpdate () {
		float newManuver = Mathf.MoveTowards (rb.velocity.x, targetManuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManuver, 0.0f, currentSpeed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundry.xMin, boundry.xMax),
			0,
			Mathf.Clamp (rb.position.z, boundry.zMin, boundry.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds (Random.Range(manuverTime.x, manuverTime.y));
			targetManuver = 0;
			yield return new WaitForSeconds (Random.Range(manuverWait.x, manuverWait.y));
		}
	}
}
