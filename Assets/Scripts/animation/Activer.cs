using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activer : MonoBehaviour {

	public void SetActive(int active)
    {
        this.gameObject.SetActive(Convert.ToBoolean(active));
    }
}
