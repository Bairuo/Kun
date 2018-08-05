using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbidBehaviour : MonoBehaviour {
    public Behaviour[] behaviours;

	public void Forbid()
    {
        foreach (Behaviour behaviour in behaviours)
        {
            if (behaviour != null)
            {
                behaviour.enabled = false;
            }
        }
    }
}
