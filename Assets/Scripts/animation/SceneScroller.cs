using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 单轴滚屏(x轴)
public class SceneScroller : MonoBehaviour {
    public GameObject target;
    public float constant = 0;      // 系数
    public float shiftMax = 0;
    float originX;
    float shift = 0;
    float playerLastX;

    void Start()
    {
        originX = transform.position.x;
        playerLastX = target.transform.position.x;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float forward = target.transform.position.x - playerLastX;
        float shiftAdd = 0;

        shiftAdd = -forward * constant;

        if(shiftMax == 0 || (shift + shiftAdd <= shiftMax && shift + shiftAdd >= -shiftMax))
        {
            shift += shiftAdd;
            transform.position = new Vector3(originX + shift, transform.position.y, 0);
        }

        playerLastX = target.transform.position.x;
	}
}
