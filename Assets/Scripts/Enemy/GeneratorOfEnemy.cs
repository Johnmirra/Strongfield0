using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorOfEnemy : MonoBehaviour
{
    [Header("First Chekpoints")]
    public Transform chekpointOne;
    public Transform chekpointTwo;
    public Transform chekpointTree;

    [Header("Start Locations")]
    public GameObject locationOne;
    public GameObject locationTwo;
    public GameObject locationThree;


    [Header("Generator")]
    public EnemyBase[] generator;

    [Header("Enemys")]
    public GameObject frigate;
    public GameObject fighter;
    public GameObject bomber;
    public GameObject mothership;

    int waveNumber = -1;
    float timer = 100;
    int enemyCounter;
    GameObject buttonStartWave;
    GameObject location;
    Transform firstChekpoint;
    bool waveOver;
    GameObject overScreen;
    bool over;
    
    private void Start()
    {
        buttonStartWave = GameObject.Find("StartWave");
        overScreen = GameObject.Find("OverScreen");
    }

    public void Restart()
    {
        waveNumber += 1;
        enemyCounter = generator[waveNumber].countInWave;
        timer = -1;
        buttonStartWave.SetActive(false);

        switch (generator[waveNumber].location)
        {
            case EnemyBase.startLocation.First:
                location = locationOne;
                firstChekpoint = chekpointOne;
                break;
            case EnemyBase.startLocation.second:
                location = locationTwo;
                firstChekpoint = chekpointTwo;
                break;
            case EnemyBase.startLocation.third:
                location = locationThree;
                firstChekpoint = chekpointTree;
                break;
        }

    }

    private void FixedUpdate()
    {
        if (timer < 100)
            if (timer < 0)
            {

                if (enemyCounter == 0)
                {
                    if (waveNumber == generator.Length - 1)
                        waveOver = true;
                    else
                    {
                        buttonStartWave.SetActive(true);
                        timer = 150;
                    }
                }
                else
                {
                    enemyCounter -= 1;
                    timer = generator[waveNumber].creepSpownTime;
                    switch (generator[waveNumber].witchEnemy)
                    {
                        case EnemyBase.enemy.Frigate:
                            GameObject creep = Instantiate(frigate, location.transform.position, Quaternion.LookRotation(firstChekpoint.position - location.transform.position));
                            Enemy enemy = creep.GetComponent<Enemy>();
                            enemy._chekpoint = firstChekpoint;
                            enemy.heatPoint += generator[waveNumber].bonusHeatPoints;
                            break;
                        case EnemyBase.enemy.Fighter:
                            creep = Instantiate(fighter, location.transform.position, Quaternion.LookRotation(firstChekpoint.position - location.transform.position));
                            enemy = creep.GetComponent<Enemy>();
                            enemy._chekpoint = firstChekpoint;
                            enemy.heatPoint += generator[waveNumber].bonusHeatPoints;
                            break;
                        case EnemyBase.enemy.Bomber:
                            creep = Instantiate(bomber, location.transform.position, Quaternion.LookRotation(firstChekpoint.position - location.transform.position));
                            enemy = creep.GetComponent<Enemy>();
                            enemy._chekpoint = firstChekpoint;
                            enemy.heatPoint += generator[waveNumber].bonusHeatPoints;
                            break;
                        case EnemyBase.enemy.Mothership:
                            creep = Instantiate(mothership, location.transform.position, Quaternion.LookRotation(firstChekpoint.position - location.transform.position));
                            enemy = creep.GetComponent<Enemy>();
                            enemy._chekpoint = firstChekpoint;
                            enemy.heatPoint += generator[waveNumber].bonusHeatPoints;
                            break;
                    }
                }
            }
            else timer -= Time.deltaTime;

        if (waveOver)
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !over)
            {
                over = true;
                overScreen.SetActive(true);
                GameObject.Find("OverText").GetComponent<Text>().text = "Level complete!";
                GameObject.Find("Next").GetComponent<UiEndScreenButton>().NextLevel = true;
                GameObject.Find("NextText").GetComponent<Text>().text = "Next Level";

                
                DataBaseLevel data = DataWork.LoadLevel();
                if (GameEngine.Engine.Level > data.levelProgress)
                    DataWork.SaveLevel(GameEngine.Engine.Level);
                
            }
    }
}
[System.Serializable]
public class EnemyBase
{
    public enum enemy
    {
        Frigate,
        Fighter,
        Bomber,
        Mothership
    }
    public enum startLocation
    {
        First,
        second,
        third
    }
    public startLocation location;
    public enemy witchEnemy;
    public int bonusHeatPoints;
    public int countInWave;
    public float creepSpownTime;
}
