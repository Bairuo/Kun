using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour {
    public GameObject curtain;
    public GameObject[] tips;
    public string tipName = "help";
    int p;

    void Start()
    {
        if(PlayerPrefs.GetInt(tipName, 0) == 0)
        {
            PlayerPrefs.SetInt(tipName, 0);
            DisplayTip();
        }
    }

    public void DisplayTip()
    {
        p = 0;
        curtain.SetActive(true);
        tips[0].SetActive(true);
    }

    public void Continue()
    {
        if(p == tips.Length - 1)
        {
            tips[p].SetActive(false);
            curtain.SetActive(false);
            return;
        }

        p++;
        tips[p - 1].SetActive(false);
        tips[p].SetActive(true);
    }
}
