//code used when useing the touch movement control scheme on android touch devices
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private bool touch;
	private int pointerID;

	void Awake()
	{
		direction = Vector2.zero;
	}

	public void OnPointerDown (PointerEventData data)
	{
		if (!touch) {
			origin = data.position;
			touch = true;
			pointerID = data.pointerId;
		}
	}

	public void OnPointerUp (PointerEventData data)
	{
		if (data.pointerId == pointerID) {
			direction = Vector2.zero;
			touch = false;
		}
	}

	public void OnDrag (PointerEventData data)
	{
		if(data.pointerId == pointerID){
			Vector2 currentPosition = data.position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw.normalized;

		}
	}

	public Vector2 GetDirection()
	{
		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
		return smoothDirection;
	}

}
