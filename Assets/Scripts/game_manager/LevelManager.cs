using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static string[] LevelNames = {"level1", "level2", "level3", "level4", "level5", "CG_56", "level6", "CG_破水", "CG_化鹏"};
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

    public static void FirstGame()
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

    public static void EnterMax()
    {
        Enter(maxlevel);
    }

    public static void NewGame()
    {
        PlayerPrefs.SetInt("maxlevel", 0);
        Enter(0);
    }

    public static void Enter(int index)
    {
        SceneManager.LoadScene(LevelNames[index]);
    }

}
