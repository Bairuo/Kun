using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour {
    public string target;
    bool hasActived = false;
    [SerializeField]
    public UnityEvent onCollisionEvent = new UnityEvent();
    public bool repeat = true;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == target && (!hasActived || repeat))
        {
            onCollisionEvent.Invoke();
            hasActived = true;
        }
    }
}
