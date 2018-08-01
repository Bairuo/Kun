using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bungee : MonoBehaviour {
    public GameObject other;
    public float springConstant = 0.1f;
    public float restLength;
    public bool AutoRestLength = true;

    void Start()
    {
        if(AutoRestLength)
        {
            restLength = (other.transform.position - this.transform.position).magnitude;
        }
    }
	
	void FixedUpdate () {
        Vector3 forward = other.transform.position - this.transform.position;
        float length = forward.magnitude;

        if(length <= restLength)
        {
            return;
        }

        float force = springConstant * (length - restLength);

        other.GetComponent<Rigidbody2D>().AddForce(-forward.normalized * force, ForceMode2D.Impulse);
	}
}
