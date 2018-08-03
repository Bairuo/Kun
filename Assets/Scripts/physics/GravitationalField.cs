using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalField : MonoBehaviour {
    public string target = "Kun";
    public float safeRadius;            // 无引力范围
    public float constant;       // 引力系数

    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 forward = transform.position - other.transform.position;
        if(other.tag == target && forward.magnitude > safeRadius)
        {
            float dis = forward.magnitude;
            other.GetComponent<Rigidbody2D>().AddForce(constant / Mathf.Pow(dis, 2) * forward.normalized, ForceMode2D.Impulse);
        }
    }
}
