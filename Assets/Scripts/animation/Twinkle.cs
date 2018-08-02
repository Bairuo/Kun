using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour {
    public bool loop = true;
    List<Frame> frames = new List<Frame>();
    int currentKey;
    bool play = false;
    float timer;

    class Frame
    {
        public float time;
        public float alpha;

        public Frame(float time, float alpha)
        {
            this.time = time;
            this.alpha = alpha;
        }
    }

    int GetPreKeyFrame(int start, float timer)
    {
        int keyNum = start;

        while(keyNum < frames.Count - 1)
        {
            if(frames[keyNum + 1].time > timer)
            {
                break;
            }
            keyNum++;
        }
        return keyNum;
    }


	void FixedUpdate () {
        if(frames.Count == 0)
        {
            return;
        }

		if(play)
        {
            timer += Time.deltaTime;
            currentKey = GetPreKeyFrame(currentKey, timer);
            
            if(currentKey < frames.Count - 1)
            {
                float alpha = Mathf.Lerp(frames[currentKey].alpha, frames[currentKey + 1].alpha, (timer - frames[currentKey].time) / (frames[currentKey + 1].time - frames[currentKey].time));
                Color color = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
            }
            else
            {
                if(loop)
                {
                    Play();
                }
                else
                {
                    Stop();
                }
            }
        }
	}

    public void Play()
    {
        currentKey = 0;
        timer = 0;
        play = true;

        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, frames[0].alpha);
    }

    public void Stop()
    {
        play = false;
    }

    public void AddKey(float time, float alpha)
    {
        frames.Add(new Frame(time, alpha));
    }

    public void ClearAllKeys()
    {
        frames.Clear();
    }
}
