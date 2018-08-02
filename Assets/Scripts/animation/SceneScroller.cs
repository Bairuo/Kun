using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 单轴滚屏(x轴)
public class SceneScroller : MonoBehaviour {
    public GameObject player;
    //public float constant = 1;      // 系数
    public float shiftConstant = 0;
    public float shiftMax = 0;
    float originX;
    float shift = 0;
    float playerLastX;

    void Start()
    {
        originX = transform.position.x;
        playerLastX = player.transform.position.x;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float forward = player.transform.position.x - playerLastX;
        float shiftAdd = 0;

        // 这么做好像有点晕？
        // shiftAdd = -forward * constant * 0.5f;

        if(player.GetComponent<Rigidbody2D>().velocity.magnitude < 1.5f)
        {
            return;
        }

        if(forward > 0)
        {
            shiftAdd = -shiftConstant;
        }
        else if(forward < 0)
        {
            shiftAdd = shiftConstant;
        }

        if(shiftMax == 0 || (shift + shiftAdd <= shiftMax && shift + shiftAdd >= -shiftMax))
        {
            shift += shiftAdd;
            transform.position = new Vector3(originX + shift, transform.position.y, 0);
        }

        playerLastX = player.transform.position.x;
	}
}
