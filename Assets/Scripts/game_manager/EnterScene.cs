using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour {

	public void Enter(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
