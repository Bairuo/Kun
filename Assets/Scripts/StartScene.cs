using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
    public GameObject setting;

	public void StartGame()
    {
        SceneManager.LoadScene("冥界忘川河");
    }

    public void PopSetting()
    {
        if(!setting.activeSelf)
        {
            setting.SetActive(true);
        }
        else
        {
            setting.SetActive(false);
        }
    }
}
