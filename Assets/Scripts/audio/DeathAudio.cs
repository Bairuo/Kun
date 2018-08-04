using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour {

	void Start () {
        GameObject BGM = GameObject.FindGameObjectWithTag("BGM");
        
        if(BGM != null)
        {
            BGM.SetActive(false);
        }
	}
	
}
