using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScreen : MonoBehaviour
{
    InputTouch inputControl;
    GameObject platform;
    Vector2 startPosition;

    public GameObject autoTurret;
    public GameObject machinegun;
    public GameObject sniper;
    public GameObject louncher;
    public GameObject flamer;
    public GameObject iceTurret;

    public BuildButtons button1;
    public BuildButtons button2;
    public BuildButtons button3;
    public BuildButtons button4;
    public BuildButtons button5;
    public BuildButtons button6;


    private void Start()
    {
        inputControl = GameObject.Find("GameEngine").GetComponent<InputTouch>();
        startPosition = transform.position;
        Hide();
    }


    void Build(string turretName)
    {
        switch (turretName)
        {
            case "AutoTurret":
                GameObject turret = Instantiate(autoTurret, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
            case "Machinegun":
                turret = Instantiate(machinegun, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
            case "Sniper":
                turret = Instantiate(sniper, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
            case "Louncher":
                turret = Instantiate(louncher, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
            case "Flamer":
                turret = Instantiate(flamer, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
            case "IceTurret":
                turret = Instantiate(iceTurret, platform.transform.position, Quaternion.identity);
                turret.SendMessage("Build", platform);
                break;
        }
        Hide();
    }



    public void Unhide(GameObject emtyPlatform)
    {
        transform.position = startPosition;
        platform = emtyPlatform;
        inputControl.screenProtector = true;

        button1.Unblock();
        button2.Unblock();
        button3.Unblock();
        button4.Unblock();
        button5.Unblock();
        button6.Unblock();
    }

    public void Hide()
    {
        transform.position = new Vector2(transform.position.x + 2000, transform.position.y);
        inputControl.screenProtector = false;
    }
}
