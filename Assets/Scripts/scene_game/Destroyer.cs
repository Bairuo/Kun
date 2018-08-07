using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string target;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == target)
        {
            Destroy(other.gameObject);
        }
    }
}
