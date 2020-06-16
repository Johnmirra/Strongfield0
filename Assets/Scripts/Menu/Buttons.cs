using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int level;


    public bool itLevelCheker;
    public int levelProgress;

    public Buttons LevelCheker;
    public bool itLevelButton;
    bool blockLevel;


    private void Awake()
    {
        if (itLevelCheker)
        {
            DataBaseLevel data = DataWork.LoadLevel();
            levelProgress = data.levelProgress;
        }
    }
    private void Start()
    {
        



        if (itLevelButton)
            if (LevelCheker.levelProgress < level-1)
            {
                GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
                blockLevel = true;
            }

            
    }

    public void PushLevel()
    {
        if(!blockLevel)
            SceneManager.LoadScene(level + 2);
    }

    public void PushBack()
    {
        SceneManager.LoadScene(0);
    }

    public void PushMaps()
    {
        SceneManager.LoadScene(1);
    }

    public void PushSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void PushExit()
    {
        Application.Quit();
    }
}
