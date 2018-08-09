using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroTrigger : MonoBehaviour {
    public string target;
    public float ShakeInterval = 3;
    bool effective = true;
    float timer = 0;

    void FixedUpdate()
    {
        if (!effective)
        {
            timer += Time.deltaTime;

            if (timer >= ShakeInterval)
            {
                timer = 0;
                effective = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == target)
        {
            if (effective)
            {
                effective = false;

                if (ScreenVibration.isshakeCamera)
                {
                    ScreenVibration.frameTime *= 2;
                }
                else
                {
                    ScreenVibration.Shake();
                }
            }
        }
    }
}
