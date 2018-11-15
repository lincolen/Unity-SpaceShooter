using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
	public Slider volumeSlider;

	 void Start(){
		volumeSlider = gameObject.GetComponent<Slider>();
		volumeSlider.value = PlayerPrefs.GetFloat("mVolume",0.5f);
	}

	public void setMasterVolume(float volume){
		AudioListener.volume = volume;
		PlayerPrefs.SetFloat ("mVolume", volume);
	}
}
