﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {
    public GameObject curtain;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Kun")
        {
            other.GetComponent<KunController>().invincible = true;
            curtain.SetActive(true);
        }
        
    }
}
