using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public float startTime = 0;
    public float FadeTime;
    public float TargetAlpha = 1;
    public bool AutoTarget = false;
    public bool CanBeInterrupted = true;
    float timer = 0;

    void Start()
    {
        Color color;
        if(GetComponent<SpriteRenderer>() != null)
        {
            color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
        }
        else if(GetComponent<Image>() != null)
        {
            color = GetComponent<Image>().color;
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);
        }
        else
        {
            return;
        }

        if(AutoTarget)
        {
            TargetAlpha = color.a;
        }
    }

    void FixedUpdate()
    {
        Color color;
        timer += Time.deltaTime;

        if(timer > startTime)
        {
            float t = timer - startTime;
            //Color color = GetComponent<SpriteRenderer>().color;
            
            if(t > FadeTime)
            {
                if (GetComponent<SpriteRenderer>() != null)
                {
                    color = GetComponent<SpriteRenderer>().color;
                    GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, TargetAlpha);
                }
                else if (GetComponent<Image>() != null)
                {
                    color = GetComponent<Image>().color;
                    GetComponent<Image>().color = new Color(color.r, color.g, color.b, TargetAlpha);
                }

                this.enabled = false;
            }
            else
            {
                float alpha = t / FadeTime * TargetAlpha;
                if (GetComponent<SpriteRenderer>() != null)
                {
                    color = GetComponent<SpriteRenderer>().color;

                    // 外部打断
                    if (CanBeInterrupted && color.a > alpha)
                    {
                        this.enabled = false;
                        return;
                    }

                    GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
                }
                else if (GetComponent<Image>() != null)
                {
                    color = GetComponent<Image>().color;

                    // 外部打断
                    if (CanBeInterrupted && color.a > alpha)
                    {
                        this.enabled = false;
                        return;
                    }

                    GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);
                }
                else
                {
                    return;
                }
            }
            
        }
    }
	
}
