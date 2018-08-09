using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour {
    Vector2 originVelocity;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Kun")
        {
            originVelocity = GetComponent<Rigidbody2D>().velocity;            
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Kun")
        {
            GetComponent<Rigidbody2D>().velocity = originVelocity;
        }
    }

}
