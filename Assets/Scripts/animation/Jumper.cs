using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    public float speed = 0.02f;
    public float boundmax = 0.8f;
    public float boundmin = 0.5f;
    float origin;
    float shift = 0;

    // Use this for initialization
    void Start()
    {
        origin = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (shift > boundmax || shift < -boundmin)
        {
            speed = -speed;
        }

        shift += speed;
        transform.position = new Vector3(transform.position.x, origin + shift, transform.position.z);
    }
}
