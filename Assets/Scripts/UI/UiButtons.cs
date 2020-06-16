using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiButtons : MonoBehaviour
{
    public GameObject contin, exit, mark;
    public bool marker;
    public GameObject TreeScreen;
    public GameObject GreyImage;

   

    private void Start()
    {
        
        if (GreyImage != null)
            GreyImage.SetActive(false);
        if (TreeScreen != null)
            TreeScreen.SetActive(false);
        if (marker)
        {
            contin.SetActive(false);
            exit.SetActive(false);
        }
    }

    public void PushMark()
    {
        GameObject.Find("GameEngine").GetComponent<AudioSource>().volume *= 0.5f;
        Time.timeScale = 0;
        contin.SetActive (true);
        exit.SetActive (true);
        mark.SetActive (false);
        GreyImage.SetActive(true);
    }

    public void PushContinue()
    {
        GameObject.Find("GameEngine").GetComponent<AudioSource>().volume *= 2f;
        exit.SetActive(false);
        mark.SetActive(true);
        Time.timeScale = 1;
        GreyImage.SetActive(false);
        contin.SetActive(false);
    }

    public void PushExit()
    {
        //return music
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void BonusTreeActive()
    {
        GameObject.Find("GameEngine").GetComponent<AudioSource>().volume *= 0.5f;
        TreeScreen.SetActive(true);
        TreeScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void TreeMark()
    {
        GameObject.Find("GameEngine").GetComponent<AudioSource>().volume *= 2f;
        Time.timeScale = 1;
        TreeScreen.SetActive(false);
    }
}
