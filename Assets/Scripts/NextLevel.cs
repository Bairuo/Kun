using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : LevelManager {
    public int nowLevel;

    public void EnterNextLevel()
    {
        Enter(nowLevel + 1);
    }
}
