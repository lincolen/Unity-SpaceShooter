using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
	public Slider volumeSlider;
	public float defaultVolume;


	private void Awake()
	{
		volumeSlider = gameObject.GetComponent<Slider>();
		volumeSlider.value = PlayerPrefs.GetFloat("mVolume",defaultVolume);
		AudioListener.volume = PlayerPrefs.GetFloat("mVolume",defaultVolume);
	}
	 void Start(){

	}

	public void setMasterVolume(float volume){

		AudioListener.volume = volume;

		PlayerPrefs.SetFloat ("mVolume", volume);
	}
}
