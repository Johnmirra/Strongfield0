using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiStartButton : MonoBehaviour
{
    public void Push()
    {
        GameObject.Find("EnemyGenerator").SendMessage("Restart");
    }
}
