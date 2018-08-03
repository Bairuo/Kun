using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingSelection : MonoBehaviour {
    public GameObject[] scrollViewItems;
    public AnimationCurve positionXAnimationCurve;
    public AnimationCurve positionYAnimationCurve;
    public float[] Xkeys;
    public float[] Ykeys;
    public float startX;
    public float startY;
    public float maxX;
    public float maxY;
    public float lerpDuration = 0.6f;
    int[] layer = new int[] {3, 4, 2, 5, 1, 0};
    float currentDuration;
    bool run = false;
    bool layerExChange = false;
    int forward;

    void Start()
    {
        for(int i = 0; i < Ykeys.Length; i++)
        {
            Ykeys[i] = 1.0f * i / Ykeys.Length;
        }
    }

    public void Right()
    {
        if(run)
        {
            return;
        }

        currentDuration = 0;
        layerExChange = false;
        forward = 1;
        run = true;
    }

    public void Left()
    {
        if(run)
        {
            return;
        }

        currentDuration = 0;
        layerExChange = false;
        forward = 0;
        run = true;
    }

    float GetPosX(int keyNum, float percent, int forward)
    {
        float sliderValue;

        if(forward == 0)
        {
            if (keyNum != 0)
            {
                sliderValue = Mathf.Lerp(Xkeys[keyNum - 1], Xkeys[keyNum], percent);
            }
            else
            {
                sliderValue = Mathf.Lerp(Xkeys[Xkeys.Length - 1], 1, percent);
            }
        }
        else
        {
            if (keyNum < Xkeys.Length - 1)
            {
                sliderValue = Mathf.Lerp(Xkeys[keyNum], Xkeys[keyNum + 1], percent);
            }
            else
            {
                sliderValue = Mathf.Lerp(Xkeys[keyNum], 1, percent);
            }
        }


        float posX = positionXAnimationCurve.Evaluate(sliderValue) * (maxX - startX) * (-Mathf.Abs(percent - 0.5f) + 1.5f);
        
        if(sliderValue - (int)sliderValue > 0.5f)
        {
            posX = -posX;
        }

        return startX + posX;
    }

    float GetPosY(int keyNum, float percent, int forward)
    {
        float sliderValue;

        if(forward == 0)
        {
            if (keyNum != 0)
            {
                sliderValue = Mathf.Lerp(Ykeys[keyNum - 1], Ykeys[keyNum], percent);
            }
            else
            {
                sliderValue = Mathf.Lerp(Ykeys[Ykeys.Length - 1], 1, percent);
            }
        }
        else
        {
            if (keyNum != Ykeys.Length - 1)
            {
                sliderValue = Mathf.Lerp(Ykeys[keyNum], Ykeys[keyNum + 1], percent);
            }
            else
            {
                sliderValue = Mathf.Lerp(Ykeys[keyNum], 1, percent);
            }
        }


        float posY = positionYAnimationCurve.Evaluate(sliderValue) * (maxY - startY);

        return startY + posY;
    }

    int GetNextKeyNum(int keyNum, int forward)
    {
        if(forward == 0)
        {
            // 向左
            return (keyNum - 1 + scrollViewItems.Length) % scrollViewItems.Length;
        }
        else
        {
            // 向右
            return (keyNum + 1) % scrollViewItems.Length;
        }
    }

	void FixedUpdate () 
    {
        if(!run)
        {
            return;
        }

        currentDuration += Time.deltaTime;
        if(currentDuration > lerpDuration)
        {
            currentDuration = lerpDuration;
        }

        float percent;

        if(forward == 1)
        {
            percent = currentDuration / lerpDuration;
        }
        else if(forward == 0)
        {
            percent = 1 - currentDuration / lerpDuration;
        }
        else
        {
            return;
        }

        for (int i = 0; i < scrollViewItems.Length; i++)
        {
            float x = GetPosX(scrollViewItems[i].GetComponent<LevelItem>().keyNum, percent, forward);
            float y = GetPosY(scrollViewItems[i].GetComponent<LevelItem>().keyNum, percent, forward);

            scrollViewItems[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);

            if (currentDuration >= lerpDuration)
            {
                scrollViewItems[i].GetComponent<LevelItem>().keyNum = GetNextKeyNum(scrollViewItems[i].GetComponent<LevelItem>().keyNum, forward);
            }
        }

        if (!layerExChange && ((percent > 0.5f && forward == 1) || (percent < 0.5f && forward == 0)))
        {
            int set = 0;
            while(set < scrollViewItems.Length)
            {
                for (int i = 0; i < scrollViewItems.Length; i++)
                {
                    if (GetNextKeyNum(scrollViewItems[i].GetComponent<LevelItem>().keyNum, forward) == layer[set])
                    {
                        scrollViewItems[i].GetComponent<RectTransform>().SetSiblingIndex(set + 1);
                        set++;
                        break;
                    }
                }
            }

            layerExChange = true;
        }

        if (currentDuration >= lerpDuration)
        {
            run = false;
        }
	}
}
