using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeEvent : MonoBehaviour {
    public float startTime;
    [SerializeField]
    public UnityEvent onActiveEvent = new UnityEvent();
    float timer = 0;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= startTime)
        {
            onActiveEvent.Invoke();
            timer = 0;
            this.enabled = false;
        }
    }
}
