using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeEvent : MonoBehaviour {
    public float startTime;
    [SerializeField]
    public UnityEvent onActiveEvent = new UnityEvent();
    public bool repeat = true;
    bool active = false;
    float timer = 0;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > startTime && (!active || repeat))
        {
            onActiveEvent.Invoke();
            timer = 0;
            active = true;
            
            this.enabled = false;
        }
    }
}
