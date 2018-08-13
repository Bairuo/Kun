using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TipController : MonoBehaviour {
    public Sprite[] tips;
    [SerializeField]
    public UnityEvent endEvent = new UnityEvent();
    int p = 0;

    public void Continue()
    {
        if(p > tips.Length - 1)
        {
            return;
        }
        else if(p == tips.Length - 1)
        {
            p++;
            endEvent.Invoke();
            return;
        }
        else
        {
            p++;
            GetComponent<Image>().sprite = tips[p];
        }
    }
}
