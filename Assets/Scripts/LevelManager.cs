using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string[] LevelNames = {"level1", "level2", "level3", "level4", "level5"};

    public void Enter(int index)
    {
        SceneManager.LoadScene(LevelNames[index]);
    }

}
