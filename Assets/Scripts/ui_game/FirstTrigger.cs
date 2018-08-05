using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FirstTrigger : MonoBehaviour {
    [SerializeField]
    public UnityEvent triggerEvent = new UnityEvent();

    bool isTriggered = false;

    public void Trigger()
    {
        if(!isTriggered)
        {
            triggerEvent.Invoke();
        }

        isTriggered = true;
    }
}
