using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetingButtons : MonoBehaviour
{
    public string myName;
    public StatsScreen statsScreen;
    public Image myIamge;
    


    public void PushNewTargetSystem()
    {
        statsScreen.turret.GetComponent<TargetingSystem>().method = myName;
        statsScreen.Unselect();
        myIamge.color = new Color(1, 1, 1, 1);
    }

}
