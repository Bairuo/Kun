using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeEvent : MonoBehaviour {
    public float startTime;
    [SerializeField]
    public UnityEvent onActiveEvent = new UnityEvent();
    bool hasActived = false;
    float timer = 0;

    void Update()
    {
        if(!hasActived)
        {
            timer += Time.deltaTime;

            if (timer >= startTime)
            {
                onActiveEvent.Invoke();
                hasActived = true;
            }
        }

    }
}
