using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    float currentDuration = 0;
    int runNum = 0;     // 本次转动次数
    int runRest = 0;    // 余下的次数
    bool layerExChange = false;
    int forward;

    void Start()
    {
        for(int i = 0; i < Ykeys.Length; i++)
        {
            Ykeys[i] = 1.0f * i / Ykeys.Length;
        }

        // LevelManager设计不当，后修改
        if (LevelManager.maxlevel > 0 && LevelManager.maxlevel <= 3)
        {
            Left(LevelManager.maxlevel);
        }
        else if(LevelManager.maxlevel == 4)
        {
            Right(2);
        }
        else if(LevelManager.maxlevel > 4)
        {
            Right(1);
        }
    }

    public void Right(int n)
    {
        if(runRest > 0)
        {
            return;
        }

        forward = 1;

        runNum = n;
        runRest = n;
    }

    public void Left(int n)
    {
        if(runRest > 0)
        {
            return;
        }

        forward = 0;

        runNum = n;
        runRest = n;
    }

    public void Right()
    {
        Right(1);
    }

    public void Left()
    {
        Left(1);
    }

    float GetSpreadX(float percent)
    {
        return -Mathf.Abs(percent - 0.5f) + 1.5f;
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


        float posX = positionXAnimationCurve.Evaluate(sliderValue) * (maxX - startX) * GetSpreadX(percent);
        
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
        if(runRest == 0)
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
            runRest--;
            currentDuration = 0;
            layerExChange = false;

            if(runRest == 0)
            {
                runNum = 0;
            }
        }
	}

}
