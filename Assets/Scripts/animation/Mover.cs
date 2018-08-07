using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public AnimationCurve curveX;
    public AnimationCurve curveY;
    public float startTime;
    public float constant = 1;
    public bool freezeX = true;
    public bool freezeY = false;
    float originalX;
    float originalY;
    float timer;

    void Start()
    {
        originalX = transform.position.x;
        originalY = transform.position.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if(timer >= startTime)
        {
            float shiftX = curveX.Evaluate(timer - startTime) * constant;
            float shiftY = curveY.Evaluate(timer - startTime) * constant;
            float x;
            float y;

            if(freezeX)
            {
                x = originalX;
            }
            else
            {
                x = originalX + shiftX;
            }

            if(freezeY)
            {
                y = originalY;
            }
            else
            {
                y = originalY + shiftY;
            }

            transform.position = new Vector3(x, y, 0);
        }
	}
}
