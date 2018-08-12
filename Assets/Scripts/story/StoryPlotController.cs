using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoryPlotController : MonoBehaviour {
    public string id;
    public bool repeat = false;
    [SerializeField]
    public UnityEvent startEvent = new UnityEvent();
    public GameObject[] cancelDisplay;
    [SerializeField]
    public UnityEvent endEvent = new UnityEvent();
    public Sprite[] sprites;
    public AudioClip[] audioclips;
    public bool developClear = false;
    Color color;
    int index = 0;

	// Use this for initialization
	void Start () {
        color = GetComponent<Image>().color;
        GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);

        if(developClear)
        {
            PlayerPrefs.SetInt(id, 0);
        }
	}

    void Switch()
    {
        if(index == 0)
        {
            GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().PauseObjects();
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a);
            GetComponent<Button>().interactable = true;

            startEvent.Invoke();
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
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);
            PlayerPrefs.SetInt(id, 1);
            GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().ContinueObjects();

            foreach (var obj in cancelDisplay)
            {
                obj.SetActive(true);
            }
            endEvent.Invoke();
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
