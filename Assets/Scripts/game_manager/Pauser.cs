using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour {
    public Behaviour[] behaviours;
    bool pause = false;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("GameOperate").GetComponent<GameOperate>().PauserRegister(this);
	}
	
    public void Pause()
    {
        foreach(Behaviour behaviour in behaviours)
        {
            if(behaviour != null)
            {
                behaviour.enabled = pause;
            }
        }

        pause = !pause;
    }
}
