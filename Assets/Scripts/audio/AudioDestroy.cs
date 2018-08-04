using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour {

	void FixedUpdate () {
		if(!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
