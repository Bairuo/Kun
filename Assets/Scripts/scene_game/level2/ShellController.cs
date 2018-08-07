using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour {
    public float ShakeInterval = 3;
    bool effective = true;
    Vector2 originVelocity;
    float timer = 0;

    void FixedUpdate()
    {
        if(!effective)
        {
            timer += Time.deltaTime;

            if(timer >= ShakeInterval)
            {
                timer = 0;
                effective = true;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Kun")
        {
            originVelocity = GetComponent<Rigidbody2D>().velocity;

            if(effective)
            {
                effective = false;

                if(ScreenVibration.isshakeCamera)
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

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Kun")
        {
            GetComponent<Rigidbody2D>().velocity = originVelocity;
        }
    }

}
