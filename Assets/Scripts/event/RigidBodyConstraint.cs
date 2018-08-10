using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyConstraint : MonoBehaviour {
    RigidbodyConstraints2D originConstraint;

    void Start()
    {
        originConstraint = GetComponent<Rigidbody2D>().constraints;
    }

	public void Freeze()
    {
        originConstraint = GetComponent<Rigidbody2D>().constraints;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	public void UnFreeze()
    {
        GetComponent<Rigidbody2D>().constraints = originConstraint;
    }
}
