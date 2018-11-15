using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public float tilt;
	public Boundry boundry;
	public GameObject shot;
	public Transform shotspwan;
	public float fireRate;
	public TouchPad touchPad;
	public FireAreaButton fireAreaButton;
	private float nextFire = 0.0F;
	private AudioSource shotSound;
	private Quaternion calibrationQuaternion;
	private bool touchMoveType;
	public Toggle moveTypeToggle;

	// Use this for initialization
	void Start () {
		// touch area control is the default

		if (PlayerPrefs.GetInt ("moveType") == 1) {
			touchMoveType = true;
			moveTypeToggle.isOn = false;
		} else {
			touchMoveType = false;
			moveTypeToggle.isOn = true;
		}

		rb = GetComponent<Rigidbody> ();
		shotSound = GetComponent<AudioSource> ();

		CalibrateAccelerometer ();
		//fixes your acceleromter controls to match the inital orientation of your phone
	}
	
	// Update is called once per frame
	void Update () {
		//key bored open screen fire command
		//	if (Input.GetButton ("Fire1") && Time.time > nextFire) {  

		if ((fireAreaButton.getFire() || Input.GetButton ("Fire1")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (shot, shotspwan.position, shotspwan.rotation) as GameObject;
			shotSound.Play ();
		}
	}

	void FixedUpdate()
	{
		 
//		for Keyboard movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movementKeybored = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 movement;

		if(touchMoveType){
//for phone acceleration movement
			Vector3 accleration = Input.acceleration;
			accleration = FixAcceleration (accleration);
			movement = new Vector3 (accleration.x, 0.0f, accleration.y);
//for phone touch movement
		}else{
			Vector2 direction = touchPad.GetDirection();
			movement = (new Vector3(direction.x,0.0f,direction.y) + movementKeybored );
		}
		//movement = movement.normalized;
		rb.velocity = movement*speed;
		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax),
			0,
			Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f,0.0f,rb.velocity.x * -tilt);	
	}

	void CalibrateAccelerometer()
	{
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
			
	}

	Vector3 FixAcceleration (Vector3 acceleration)
	{
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return (fixedAcceleration);
	}

// false for touch control true for accaleration control 
	public void setTouchMoveType(bool type){
		touchMoveType = type;
		if (type) {
			PlayerPrefs.SetInt ("moveType", 1);
		} else {
			PlayerPrefs.SetInt ("moveType", 0);
		}
	}
}
