using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {
    public AudioSource audio;

	public void ChangeVolume()
    {
        audio.volume = GetComponent<Slider>().value; 
    }
}
