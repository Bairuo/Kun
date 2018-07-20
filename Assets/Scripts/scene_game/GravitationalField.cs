using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalField : MonoBehaviour {
    public string target = "Kun";
    public float radius;            // 无引力范围
    public float gravitation;       // 引力大小

    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 forward = transform.position - other.transform.position;
        if(other.tag == target && forward.magnitude > radius)
        {
            other.GetComponent<Rigidbody2D>().AddForce(forward.normalized * gravitation, ForceMode2D.Impulse);
        }
    }
}
