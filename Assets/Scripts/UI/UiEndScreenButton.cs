using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEndScreenButton : MonoBehaviour
{
    public bool NextLevel;

    public void PushNewLevel()
    {
        if (NextLevel)
            SceneManager.LoadScene(GameEngine.Engine.Level + 3);
        else
            SceneManager.LoadScene(GameEngine.Engine.Level + 2);
    }


    public void PushMenu()
    {
        SceneManager.LoadScene(0);
    }
}
