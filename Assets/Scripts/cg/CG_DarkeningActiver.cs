using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_DarkeningActiver : MonoBehaviour {
    public GameObject Darkening;
    public float startTime = -1;
    float timer = 0;

    void FixedUpdate()
    {
        if(startTime >= 0)
        {
            timer += Time.deltaTime;
            if(timer >= startTime)
            {
                StartDarkening();
                this.enabled = false;
            }
        }
    }

    public void StartDarkening()
    {
        Darkening.SetActive(true);
    }

}
