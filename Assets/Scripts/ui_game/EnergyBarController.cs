using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour {
    public GameObject kun;
    public GameObject energy;
    public Image divider;
    KunController kc;
    EnergeController ec;
    Slider slider;
    public int totalvalue; // 鲲和伴随物的总能量，对应着滑条的值
    public int kunvalue; // 鲲的能量
    public int geminivalue;  //伴随物能量
    float targetvalue;
    public float targetdividerposition;

    int maxEnergy;

    // Use this for initialization
    void Start() {
        kc = kun.GetComponent<KunController>();
        ec = energy.GetComponent<EnergeController>();
        slider = GetComponent<Slider>();
        slider.value = 1;

        maxEnergy = kc.energy + ec.energy;
    }

    // Update is called once per frame
    void Update() {
        kunvalue = kc.energy;
        geminivalue = ec.energy;
        totalvalue = kunvalue + geminivalue;
        targetvalue = (float)totalvalue / maxEnergy;
        if (slider.value != targetvalue)
        {
            if (slider.value < targetvalue)
                slider.value += 0.001f;
            else
                slider.value -= 0.001f;
        }
        targetdividerposition = targetvalue * ((float)kunvalue / totalvalue);
        if(getdividerposition() != targetdividerposition)
        {
            if (getdividerposition() < targetdividerposition)
                dividerlocate(getdividerposition() + 0.001f);
            else
                dividerlocate(getdividerposition() - 0.001f);
        }
    }

    void dividerlocate(float position)
    {
        float posx = 696 * position;
        posx -= 348;
        divider.rectTransform.anchoredPosition = new Vector3(posx, -5.9f, 0f);
    }
    float getdividerposition()
    {
        float posx = divider.rectTransform.anchoredPosition.x;
        return (posx + 348) / 696;
    }
}
