using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : LevelManager {
    public int nowLevel;

    public void EnterNextLevel()
    {
        int maxlevel = LevelManager.maxlevel;
        
        if(maxlevel == nowLevel)
        {
            LevelManager.UpdateMaxLevel(nowLevel + 1);
        }

        Enter(nowLevel + 1);
    }
}
