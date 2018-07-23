using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Scene : MonoBehaviour {
    public GameObject Whitening;
    public Animator[] animators;
    bool init = false;

	// Use this for initialization
	void Start () {
		foreach(var item in animators)
        {
            item.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(!Whitening.activeSelf && !init)
        {
            init = true;
            foreach(var item in animators)
            {
                item.enabled = true;
            }
        }
	}
}
