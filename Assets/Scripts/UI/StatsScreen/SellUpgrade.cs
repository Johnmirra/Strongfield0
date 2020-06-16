using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SellUpgrade : MonoBehaviour
{
    public StatsScreen statsScreen;
    bool readyForUgrade;
    public Image myButton;
    public Text upgradeText;
    public Text BonusTextDamage, BonusTextRadius;

    public void Upgrade()
    {
        if (statsScreen.turret.GetComponent<TurretStats>().towerLevel < GameMechanics.Mechanics.MaxTowerLvl)
        {
            if (!readyForUgrade)
            {
                statsScreen.turret.SendMessage("ShowRadiusPlus", true);
                myButton.color = new Color(1, 0.3f, 0);
                BonusTextDamage.color = new Color(0, 1, 0.2f, 1);
                BonusTextRadius.color = new Color(0, 1, 0.2f, 1);
                switch (statsScreen.turret.tag)
                {
                    case "AutoTurret":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upAutoturret.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upAutoturret)
                            readyForUgrade = true;
                        break;
                    case "Machinegun":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upMachinegun.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upMachinegun)
                            readyForUgrade = true;
                        break;
                    case "Sniper":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upSniper.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upSniper)
                            readyForUgrade = true;
                        break;
                    case "Flamer":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upFlamer.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upFlamer)
                            readyForUgrade = true;
                        break;
                    case "IceTurret":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upIceTurret.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upIceTurret)
                            readyForUgrade = true;
                        break;
                    case "Louncher":
                        upgradeText.text = "Cost " + "-" + GameMechanics.Mechanics.upLouncher.ToString();
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upLouncher)
                            readyForUgrade = true;
                        break;

                }



            }
            else
            {
                statsScreen.turret.SendMessage("ShowRadiusPlus", false);
                BonusTextDamage.color = new Color(0, 1, 0.2f, 0);
                BonusTextRadius.color = new Color(0, 1, 0.2f, 0);
                UnUpgrade();
                statsScreen.turret.SendMessage("Upgrade");
                statsScreen.RestatusStats();
                switch (statsScreen.turret.tag)
                {
                    case "AutoTurret":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upAutoturret)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upAutoturret;
                        break;
                    case "Machinegun":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upMachinegun)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upMachinegun;
                        break;
                    case "Sniper":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upSniper)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upSniper;
                        break;
                    case "Flamer":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upFlamer)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upFlamer;
                        break;
                    case "IceTurret":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upIceTurret)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upIceTurret;
                        break;
                    case "Louncher":
                        if (GameEngine.Engine.coins >= GameMechanics.Mechanics.upLouncher)
                            GameEngine.Engine.coins -= GameMechanics.Mechanics.upLouncher;
                        break;

                }
                if (statsScreen.turret.GetComponent<TurretStats>().towerLevel == GameMechanics.Mechanics.MaxTowerLvl)
                    this.gameObject.SetActive(false);
            }
        }
    }

    public void UnUpgrade()
    {
        upgradeText.text = "Upgrade";
        myButton.color = new Color(1, 1, 1);
        readyForUgrade = false;
    }

    public void Sell()
    {
        statsScreen.turret.SendMessage("DestroyTurret");
        statsScreen.Hide();
        GameEngine.Engine.coins += GameMechanics.Mechanics.turretSellReward;
    }
}
