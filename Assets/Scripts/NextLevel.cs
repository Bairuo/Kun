using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : LevelManager {
    public int nowLevel;

    public void EnterNextLevel()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        
        if(maxlevel == nowLevel)
        {
            PlayerPrefs.SetInt("maxlevel", nowLevel + 1);
        }

        Enter(nowLevel + 1);
    }
}
