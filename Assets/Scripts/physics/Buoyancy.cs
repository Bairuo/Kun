using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour {
    public float maxDepth;
    public float volume;
    public float liquidDensity;
    bool active = false;
    bool init = false;
    float surfaceHeight;
    
	public void Active()
    {
        active = true;
        init = false;
    }

    public void DeActive()
    {
        active = false;
        init = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(active)
        {
            if(!init)
            {
                surfaceHeight = transform.position.y;
                init = true;
            }

            float depth = transform.position.y;

            if(depth > surfaceHeight + maxDepth)
            {
                return;
            }
            else if(depth <= surfaceHeight - maxDepth)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, liquidDensity * volume), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, liquidDensity * volume * (depth - maxDepth - surfaceHeight) / 2 * maxDepth), ForceMode2D.Impulse);
            }
            
        }
	}
}
