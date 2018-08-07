using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnActive : MonoBehaviour {
    public GameObject target;
    public string fatherName = "";
    public string targetName = "";
    public bool findByName = false;
    [SerializeField]
    public UnityEvent onActiveEvent = new UnityEvent();
    bool isActive = false;

    void Start()
    {
        if(findByName && fatherName != null && targetName != null)
        {
            // ?? string not defined
            //GameObject find = GameObject.FindGameObjectWithTag(fatherName).transform.Find(targetName).gameObject;
            GameObject find = GameObject.FindGameObjectWithTag("GameCanvas").transform.Find("DeathCurtain").gameObject;
            if(find != null)
            {
                target = find;
            }
        }
    }

    void Update()
    {
        if (!isActive && target.activeSelf)
        {
            onActiveEvent.Invoke();
            isActive = true;
        }
    }
}
