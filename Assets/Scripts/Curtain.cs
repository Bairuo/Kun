using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Curtain : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("开始游戏");
    }
}
