using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string[] LevelNames = {"level1", "level2", "level3", "level4", "level5", "CG_56", "level6", "CG_破水", "CG_化鹏"};
    public static int maxlevel = 0;
    public bool develop = false;
 
    void Start()
    {
        if(develop)
        {
            PlayerPrefs.DeleteAll();
        }

        if(!PlayerPrefs.HasKey("maxlevel"))
        {
            PlayerPrefs.SetInt("maxlevel", 0);
        }

        maxlevel = PlayerPrefs.GetInt("maxlevel", 0);
    }

    public void FirstGame()
    {
        if(!PlayerPrefs.HasKey("FirstGame"))
        {
            PlayerPrefs.SetInt("FirstGame", 1);
            SceneManager.LoadScene("CG_开始");
        }
        else
        {
            Enter(0);
        }
    }

    public void EnterMax()
    {
        Enter(maxlevel);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("maxlevel", 0);
        Enter(0);
    }

    public void Enter(int index)
    {
        SceneManager.LoadScene(LevelNames[index]);
    }

}
