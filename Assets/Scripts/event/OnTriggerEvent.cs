using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour {
    public string target;
    [SerializeField]
    public UnityEvent onTriggerEvent = new UnityEvent();
    bool hasActived = false;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == target && !hasActived)
        {
            onTriggerEvent.Invoke();
            hasActived = true;
        }
    }
}
