using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour {
    public float target;
    public float endY;
    public float startY;
    public bool autoStart = false;

	// Use this for initialization
	void Start () {
        if(autoStart)
        {
            startY = transform.position.y;
        }
	}
	
	void FixedUpdate () {
        float scale = Mathf.Lerp(1, target, (transform.position.y - startY) / (endY - startY));
        transform.localScale = new Vector3(scale, scale, 1);
	}
}
