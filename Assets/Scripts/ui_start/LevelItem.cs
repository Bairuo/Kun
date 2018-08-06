using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour {
    public Sprite ActivedImage;
    public Sprite InactivatedImage;
    public int activeLevel;
    public int keyNum;
    public int enterLevel;
    bool levelActive;

	// Use this for initialization
	void Start () {
		if(activeLevel > LevelManager.maxlevel)
        {
            levelActive = false;
            GetComponent<Image>().sprite = InactivatedImage;
        }
        else
        {
            levelActive = true;
            GetComponent<Image>().sprite = ActivedImage;
        }
	}

    public void Onclick()
    {
        if(keyNum == 0 && levelActive)
        {
            LevelManager.Enter(enterLevel);
        }
    }
}
