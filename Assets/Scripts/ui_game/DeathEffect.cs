using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathEffect : MonoBehaviour {
    public Text textOutput;
    public GameObject[] buttons;
    public string text = "残丝断魂，名登鬼录；朝生暮往，向死而生。";
    public float frequency = 1.0f;
    float timer = 0;
    int i = 0;

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= frequency)
        {
            timer = 0;

            if(i < text.Length)
            {
                textOutput.text += text[i];
                i++;
            }
            else
            {
                foreach(var item in buttons)
                {
                    item.SetActive(true);
                }

                this.enabled = false;
            }

        }
	}
}
