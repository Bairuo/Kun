using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathEffect : MonoBehaviour {
    public Shader postEffect;
    public Text textOutput;
    public GameObject[] hideButtons;
    public GameObject[] displayButtons;
    public string text = "残丝断魂，名登鬼录；朝生暮往，向死而生。";
    public float frequency = 1.0f;
    float timer = 0;
    int i = 0;

    void Start()
    {
        foreach(var item in hideButtons)
        {
            item.SetActive(false);
        }

        GameObject.FindGameObjectWithTag("MainCamera").AddComponent<BlackWhiteEffect>();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BlackWhiteEffect>().shader = postEffect;
    }

	
    public void ImmediateExecute()
    {
        while(i <= text.Length)
        {
            Excute(i);
            i++;
        }
    }

    void Excute(int i)
    {
        if (i < text.Length)
        {
            textOutput.text += text[i];
            if (i + 1 == text.Length / 2)
            {
                textOutput.text += System.Environment.NewLine;
            }
        }
        else
        {
            foreach (var item in displayButtons)
            {
                item.SetActive(true);
            }

            this.enabled = false;
        }
    }

	void Update () {
        timer += Time.deltaTime;

        if(timer >= frequency)
        {
            timer = 0;

            Excute(i);
            i++;
        }
	}
}
