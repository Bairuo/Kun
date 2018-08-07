using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellGenerator : MonoBehaviour {
    public GameObject shell;
    public Vector2 forward;
    public float strength;
    public float startTime;
    public AnimationCurve intervalCurve;
    float shootTimer = -1;
    float timer = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if(timer > startTime)
        {
            shootTimer -= Time.deltaTime;

            if(shootTimer < 0)
            {
                Instantiate(shell, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(strength * forward.normalized);

                shootTimer = intervalCurve.Evaluate(timer - startTime);
            }
        }
	}
}
