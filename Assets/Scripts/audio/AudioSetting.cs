using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {
    static float audioVolume = 0.618f;
    static float audioEffectVolume = 0.618f;

    public Slider AudioSlider;    // 音乐
    public Slider AudioEffectSlider;      // 音效   

    public GameObject BGMPrefab;
    AudioSource BGM;
    public AudioSource[] audioEffects;

    void Start()
    {
        GameObject existBGM = GameObject.FindGameObjectWithTag("BGM");

        if(existBGM == null)
        {
            BGM = Instantiate(BGMPrefab).GetComponent<AudioSource>();
        }
        else
        {
            if(existBGM.GetComponent<AudioSource>().clip.name != BGMPrefab.GetComponent<AudioSource>().clip.name)
            {
                Destroy(existBGM);
                BGM = Instantiate(BGMPrefab).GetComponent<AudioSource>();
            }
            else
            {
                BGM = existBGM.GetComponent<AudioSource>();
            }
        }

        AudioSlider.value = audioVolume;
        AudioEffectSlider.value = audioEffectVolume;

        ChangeAudio();
        ChangeAudioEffects();
    }

	public void ChangeAudio()
    {
        BGM.volume = AudioSlider.value;
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
