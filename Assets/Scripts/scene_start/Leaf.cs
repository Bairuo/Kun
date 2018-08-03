using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {
    public float strength = 100;
    public float rotate = 2;
    public float maxSpeed = 5;

	void Start () {
        float emissionAngle = Random.Range(0, 2 * Mathf.PI);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sin(emissionAngle), Mathf.Cos(emissionAngle)) * strength);
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 2 * Mathf.PI) * rotate);
	}
	
    void FixedUpdate()
    {
        //if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        //{
        //    GetComponent<Rigidbody2D>().velocity *= maxSpeed / GetComponent<Rigidbody2D>().velocity.magnitude;
        //}
    }
}
