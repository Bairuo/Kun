using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoryPlotController : MonoBehaviour {
    public string id;
    public bool repeat = false;
    public GameObject[] cancelDisplay;
    public Sprite[] sprites;
    public AudioClip[] audioclips;
    public bool developClear = false;
    int index = 0;

	// Use this for initialization
	void Start () {

        if(developClear)
        {
            PlayerPrefs.SetInt(id, 0);
        }
	}

    void Update()
    {
        if(index == 0)
        {
            Switch();
        }
    }

    void Switch()
    {
        if(index == 0)
        {
            GameObject.FindGameObjectWithTag("Rocker").GetComponent<Rocker>().ForceReset();
            GameObject.FindGameObjectWithTag("Rocker").SetActive(false);
            GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().PauseObjects();

            foreach(var obj in cancelDisplay)
            {
                obj.SetActive(false);
            }
        }

        if(index < sprites.Length)
        {
            GetComponent<Image>().sprite = sprites[index];

            GetComponent<AudioSource>().Stop();
            if(audioclips[index] != null)
            {
                GetComponent<AudioSource>().clip = audioclips[index];
                GetComponent<AudioSource>().Play();
            }

            index++;
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt(id, 1);
            GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().ContinueObjects();

            foreach (var obj in cancelDisplay)
            {
                obj.SetActive(true);
            }

            this.gameObject.SetActive(false);
        }
    }


    public void OnTrigger()
    {
        if(!repeat && PlayerPrefs.GetInt(id, 0) == 0)
        {
            Switch();
        }
    }
}
