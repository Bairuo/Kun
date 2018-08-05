using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnActive : MonoBehaviour {
    public GameObject target;
    [SerializeField]
    public UnityEvent onActiveEvent = new UnityEvent();
    bool isActive = false;

    void Update()
    {
        if (!isActive && target.activeSelf)
        {
            onActiveEvent.Invoke();
            isActive = true;
        }
    }
}
