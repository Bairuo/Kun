using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour {
    public Sprite ActivedImage;
    public Sprite InactivatedImage;
    public int level;
    public int keyNum;
    bool levelActive;

	// Use this for initialization
	void Start () {
		if(level > LevelManager.maxlevel)
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
            LevelManager.Enter(level);
        }
    }
}
