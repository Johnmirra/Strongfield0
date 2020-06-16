using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public int Level;
    public static GameEngine Engine;
    public GameObject Base;
    public GameObject BaseExplosion;
    float boomTimer = 10;
    Text coinsText;
    Text livesText;

    [Header("Engine")]
    public GameObject canvasS;
    public GameObject canvasM;
    public float soundEffectVolume;

    [Header("CameraBox")]
    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;
    [Header("Camera Zoom")]
    public float mixY;
    public float maxY;

    [Header("Coins")]
    public int coins =300;
    int lives = 20;
    public GameObject endScreen;

    private void Awake()
    {
        Engine = this;
        if (Screen.width > 2000)
            Instantiate(canvasM);
        else
            Instantiate(canvasS);
        
        
    }
    private void Start()
    {
        endScreen = GameObject.Find("OverScreen");
        coinsText = GameObject.Find("CoinsText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        endScreen.SetActive(false);
    }


    private void FixedUpdate()
    {
        
        coinsText.text = coins.ToString();
        if (boomTimer < 5)
            if (boomTimer < 0)
            {
                Time.timeScale = 0;
                endScreen.SetActive(true);
                GameObject.Find("OverText").GetComponent<Text>().text = "Level is failed!";
                GameObject.Find("Next").GetComponent<UiEndScreenButton>().NextLevel = false;
                GameObject.Find("NextText").GetComponent<Text>().text = "Restart";
            }
            else boomTimer -= Time.deltaTime;
    }

    public void LiveMinus()
    {
        lives -= 1;
        livesText.text = lives.ToString();
        if(lives == 0)
        {
            boomTimer = 3f;
            Instantiate(BaseExplosion,Base.transform.position,Quaternion.identity);
            Destroy(Base);
        }

    }
}
