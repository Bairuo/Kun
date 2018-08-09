using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPowerGenerator : MonoBehaviour {
    public string target;
    public float constant;
    float restLength;

    void Start()
    {
        restLength = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(target == other.gameObject.tag)
        {
            Vector3 forward = other.transform.position - this.transform.position;
            float length = forward.magnitude;

            float force = constant * Mathf.Abs(restLength - length);

            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
        }
    }
}
