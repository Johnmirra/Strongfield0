using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtons : MonoBehaviour
{
    public GameObject buildScreen;
    public string myName;

    public void PushBuild()
    {
        switch (myName)
        {
            case "AutoTurret":
                if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costAutoturret)
                {
                    buildScreen.SendMessage("Build", myName);
                    GameEngine.Engine.coins -= GameMechanics.Mechanics.costAutoturret;
                }
                break;
            case "Machinegun":
                if (GameMechanics.Mechanics.machinegun)
                    if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costMachinegun)
                    {
                        buildScreen.SendMessage("Build", myName);
                        GameEngine.Engine.coins -= GameMechanics.Mechanics.costMachinegun;
                    }
                break;
            case "Sniper":
                if (GameMechanics.Mechanics.sniper)
                    if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costSniper)
                    {
                        buildScreen.SendMessage("Build", myName);
                        GameEngine.Engine.coins -= GameMechanics.Mechanics.costSniper;
                    }
                break;
            case "Flamer":
                if (GameMechanics.Mechanics.flamer)
                    if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costFlamer)
                    {
                        buildScreen.SendMessage("Build", myName);
                        GameEngine.Engine.coins -= GameMechanics.Mechanics.costFlamer;
                    }
                break;
            case "IceTurret":
                if (GameMechanics.Mechanics.iceTurret)
                    if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costIceTurret)
                    {
                        buildScreen.SendMessage("Build", myName);
                        GameEngine.Engine.coins -= GameMechanics.Mechanics.costIceTurret;
                    }
                break;
            case "Louncher":
                if (GameMechanics.Mechanics.louncher)
                    if (GameEngine.Engine.coins >= GameMechanics.Mechanics.costLouncher)
                    {
                        buildScreen.SendMessage("Build", myName);
                        GameEngine.Engine.coins -= GameMechanics.Mechanics.costLouncher;
                    }
                
                break;
        }
    }

    public void Unblock()
    {
        switch (myName)
        {
            case "Machinegun":
                if (GameMechanics.Mechanics.machinegun)
                    GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Sniper":
                if (GameMechanics.Mechanics.sniper)
                    GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Flamer":
                if (GameMechanics.Mechanics.flamer)
                    GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "IceTurret":
                if (GameMechanics.Mechanics.iceTurret)
                    GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Louncher":
                if (GameMechanics.Mechanics.louncher)
                    GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
        }
    }
}
