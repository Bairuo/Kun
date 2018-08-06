using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {
    public GameObject[] FirstGameGroup;
    public GameObject[] NoFirstGroup;

	// Use this for initialization
	void Start () {
        int maxlevel = LevelManager.maxlevel;

        if(maxlevel == 0)
        {
            foreach(var item in FirstGameGroup)
            {
                item.SetActive(true);
            }

            foreach(var item in NoFirstGroup)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (var item in FirstGameGroup)
            {
                item.SetActive(false);
            }

            foreach (var item in NoFirstGroup)
            {
                item.SetActive(true);
            }
        }
	}
	
}
