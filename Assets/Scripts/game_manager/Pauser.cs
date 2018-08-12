using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour {
    public Behaviour[] behaviours;
    public bool sleepRigidBody = false;
    Vector2 velocity;
    bool pause = false;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().PauserRegister(this);
	}
	
    public void Pause()
    {
        if(pause)
        {
            return;
        }

        foreach(Behaviour behaviour in behaviours)
        {
            if(behaviour != null)
            {
                behaviour.enabled = false;
            }
        }

        if(sleepRigidBody)
        {
            velocity = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().Sleep();
        }

        pause = true;
    }

    public void Continue()
    {
        if(!pause)
        {
            return;
        }

        foreach (Behaviour behaviour in behaviours)
        {
            if (behaviour != null)
            {
                behaviour.enabled = true;
            }
        }

        if (sleepRigidBody)
        {
            GetComponent<Rigidbody2D>().WakeUp();
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

        pause = false;
    }
}
