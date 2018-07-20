using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GeminiController gemini;     // 边界
    public Transform target;    // 摄像机跟随目标
    public float offsetX = 4;    // 由于玩家宽度导致的边界偏移（扩大）
    public float offsetY = 4;    // 由于玩家高度导致的边界偏移（扩大）
    Vector2 buffer;
    float originX;
    float originY;
    float originZ;

    float leftBorder;
    float rightBorder;
    float topBorder;
    float downBorder;

    float width;        // 分辨率宽度对应的游戏世界宽度
    float height;

	// Use this for initialization
	void Start () {
        originX = transform.position.x;
        originY = transform.position.y;
        originZ = transform.position.z;

        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));

        leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        rightBorder = cornerPos.x;
        topBorder = cornerPos.y;
        downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);

        width = rightBorder - leftBorder;
        height = topBorder - downBorder;
	}

    void LateUpdate()
    {
        
        if(gemini.boundary[2] - offsetX + width / 2 < target.position.x && target.position.x < gemini.boundary[3] + offsetX - width / 2)
        {
            transform.position = new Vector3(target.position.x, originY, originZ);
        }
        else
        {
            transform.position = new Vector3(originX, originY, originZ);
        }


        if(gemini.boundary[0] + offsetY - height / 2 > target.position.y && target.position.y > gemini.boundary[1] - offsetY + height / 2)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, originZ);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, originY, originZ);
        }

        originX = transform.position.x;
        originY = transform.position.y;
        originZ = transform.position.z;
    }
}
