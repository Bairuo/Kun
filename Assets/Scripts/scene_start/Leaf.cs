using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {
    public float shootStrength = 120;
    public float gravitationStrength = 0.04f;
    public float gravitationActiveTime = 5;
    public float rotate = 2;
    float timer = 0;
    bool gravitationActive = false;

	void Start () {
        float emissionAngle = Random.Range(0, 2 * Mathf.PI);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(shootStrength * Mathf.Sin(emissionAngle), Mathf.Cos(emissionAngle)));
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(0, 2 * Mathf.PI) * rotate);
	}
	
    void FixedUpdate()
    {
        if(!gravitationActive)
        {
            timer += Time.deltaTime;
        }
        

        if(timer >= gravitationActiveTime)
        {
            gravitationActive = true;
        }

        if(gravitationActive)
        {
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;

            GetComponent<Rigidbody2D>().AddForce(gravitationStrength * new Vector2(x, y), ForceMode2D.Impulse);
        }
    }
}
