using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseByTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private bool touchPasue;
	public float timeTilPasue;
	private float touchTime;
	public PauseGame pauseGameScript;
	private int touchCount;
	private int touchID;
	// Use this for initialization
	void Start () {
		touchPasue = false;
		touchTime = 0;
		touchCount = 0;
	}

	public void OnPointerDown(PointerEventData data){
		touchCount++;
		touchID = data.pointerId;
		Debug.Log ("hello");
	}

	public void OnPointerUp(PointerEventData data){
		touchCount--;
	}
	// Update is called once per frame
	void Update () {
		
		if (touchCount > 0) {
			
			if (Input.GetTouch (touchID).phase == TouchPhase.Stationary) {
				touchTime = touchTime + Time.deltaTime;
				Debug.Log (touchTime);
			}
			if (Input.GetTouch (touchID).phase == TouchPhase.Ended) {
				touchTime = 0;
			}
		}
		if (touchTime > timeTilPasue) {
			pauseGameScript.setPasue (true);
			touchTime = 0;
		}
		
	}
}
