using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public float startTime = 0;
    public float FadeTime;
    float timer = 0;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer > startTime)
        {
            float t = timer - startTime;
            Color color = GetComponent<SpriteRenderer>().color;
            
            if(t > FadeTime)
            {
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);
                this.enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, t / FadeTime);
            }
            
        }
    }
	
}
