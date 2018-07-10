using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float originY;
    float originZ;

	// Use this for initialization
	void Start () {
        originY = transform.position.y;
        originZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, originY, originZ);
    }
}
