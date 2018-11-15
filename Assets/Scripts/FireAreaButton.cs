using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private bool canFire;
	private bool autoFire;
	private int tochCount;
	public double doubleTapTime;
	private int lastTouch;
	private double lastTouchTime;

	void Awake()
	{
		canFire = false;
		autoFire = false;
		tochCount = 0;
	}

	public void OnPointerDown(PointerEventData data){
// enables and diables auto fire
		if (lastTouch == data.pointerId) {
			if ((Time.time - lastTouchTime) < doubleTapTime) {
				autoFire = !autoFire;
			}

		//	Debug.Log (Time.time - lastTouchTime);
		//	Debug.Log ((Time.time - lastTouchTime) < doubleTapTime);
		//	Debug.Log (autoFire);
		//	Debug.Log(canFire||autoFire);	
		}
		lastTouch = data.pointerId;
		lastTouchTime = Time.fixedTime;

		tochCount++;
		setFire ();

	}

	public void OnPointerUp(PointerEventData data){
		tochCount--;
		setFire ();
	}

	public void setFire(){
		if (tochCount > 0) {
			canFire = true;
		} else {
			canFire = false;
		}
	}

	public bool getFire(){
		return (canFire||autoFire);
	}

}
