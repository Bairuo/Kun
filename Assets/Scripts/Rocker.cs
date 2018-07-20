using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocker : MonoBehaviour {
    public GameObject viewport;
    public GameObject joy;
    public Vector2 relative;      // 相对锚点的向量
    public float x, y;
    public int r;
    float PosX, PosY;
    bool display = false;

    void Start()
    {
        PosX = GetComponent<RectTransform>().position.x;
        PosY = GetComponent<RectTransform>().position.y;
    }

    public void DisPlay()
    {
        display = true;
        GetComponent<RectTransform>().position = new Vector3(GetRockerTouchPosition().x, GetRockerTouchPosition().y, 0);
        Color viewportColor = viewport.GetComponent<Image>().color;
        Color joyColor = joy.GetComponent<Image>().color;
        viewport.GetComponent<Image>().color = new Color(viewportColor.r, viewportColor.g, viewportColor.b, 1);
        joy.GetComponent<Image>().color = new Color(joyColor.r, joyColor.g, joyColor.b, 1);
    }

    public void CancelDisPlay()
    {
        display = false;
        GetComponent<RectTransform>().position = new Vector3(PosX, PosY, 0);
        Color viewportColor = viewport.GetComponent<Image>().color;
        Color joyColor = joy.GetComponent<Image>().color;
        viewport.GetComponent<Image>().color = new Color(viewportColor.r, viewportColor.g, viewportColor.b, 20.0f / 255);
        joy.GetComponent<Image>().color = new Color(joyColor.r, joyColor.g, joyColor.b, 20.0f / 255);
    }

    public Vector3 GetRockerTouchPosition()
    {
        if (Input.touchCount == 0)
        {
            return Input.mousePosition;
        }
        else
        {
            foreach (var touch in Input.touches)
            {
                if (touch.position.x < 1.0f * Screen.width * 0.6f)
                {
                    return touch.position;
                }
            }
        }
        //Debug.Log("get touch fail");
        return Input.mousePosition;
    }
    
    public void OnMove(RectTransform rect)
    {
        Vector2 anchoredPosition = GetRockerTouchPosition() - viewport.GetComponent<RectTransform>().position;       //scroll rect手指滑动不敏感
        if(display)
        {
            rect.anchoredPosition = anchoredPosition;
        }
        

        if (rect.anchoredPosition.magnitude > r)
        {
            rect.anchoredPosition = rect.anchoredPosition.normalized * r;    // 将摇杆限制在 半径 r 以内
        }
        relative = rect.anchoredPosition;
        x = rect.anchoredPosition.normalized.x;
        y = rect.anchoredPosition.normalized.y;
    }
}
