using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {
    static float audioVolume = 0.618f;
    static float audioEffectVolume = 0.618f;

    public Slider AudioSlider;    // 音乐
    public Slider AudioEffectSlider;      // 音效   

    public AudioSource audio;
    public AudioSource[] audioEffects;

    void Start()
    {
        AudioSlider.value = audioVolume;
        AudioEffectSlider.value = audioEffectVolume;

        ChangeAudio();
        ChangeAudioEffects();
    }

	public void ChangeAudio()
    {
        audio.volume = AudioSlider.value;
        audioVolume = AudioSlider.value;
    }

    public void ChangeAudioEffects()
    {
        foreach(var audio in audioEffects)
        {
            audio.volume = AudioEffectSlider.value;
        }
        audioEffectVolume = AudioEffectSlider.value;
    }
}
