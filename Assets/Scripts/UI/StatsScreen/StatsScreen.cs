using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour
{
    InputTouch inputControl;

    public GameObject turret;
    Vector2 startPosition;

    public Image[] targetingButtonsSelection;
    public SellUpgrade upgradeButton;
    public GameObject UpgradeB;

    [Header("Stats stuf")]
    public Text turretLevel;
    public Text damageText;
    public Text damageStat;
    public Text radiusStat;
    public Text damageBonus;
    public Text radiusBonus;

    private void Start()
    {
        Unselect();
        inputControl = GameObject.Find("GameEngine").GetComponent<InputTouch>();
        startPosition = transform.position;
        Hide();
    }



    public void Unhide(GameObject tur)
    {
        if (turret != null)
        {
            turret.SendMessage("ShowRadius", false);
            turret.SendMessage("ShowRadiusPlus", false);
        }
        turret = tur;
        turret.SendMessage("ShowRadius", true);
        transform.position = startPosition;
        inputControl.screenProtector = true;
        if (turret.GetComponent<TurretStats>().towerLevel < GameMechanics.Mechanics.MaxTowerLvl)
        {
            UpgradeB.SetActive(true);
            upgradeButton.UnUpgrade();
        }
        else
            UpgradeB.SetActive(false);
        WhoSelect();
        RestatusStats();
    }

    public void Hide()
    {
        if (turret != null)
        {
            turret.SendMessage("ShowRadius", false);
            turret.SendMessage("ShowRadiusPlus", false);
        }
        transform.position = new Vector2(transform.position.x + 2000, transform.position.y);
        inputControl.screenProtector = false;
    }


    public void Unselect()
    {
        foreach(var mar in targetingButtonsSelection)
        {
            mar.color = new Color(1, 1, 1, 0);
        }
    }

    public void RestatusStats()
    {
        TurretStats stats = turret.GetComponent<TurretStats>();

        radiusStat.text = stats.radius.ToString();
        turretLevel.text = "Tower Level: " + stats.towerLevel.ToString();

        if (stats.turretName == "IceTurret")
        {
            damageText.text = "Freeze: ";
            damageStat.text = (100 - stats.FreezeSpeed * 100).ToString() + "%";
        }
        else
        {
            damageText.text = "Damage: ";
            damageStat.text = stats.Damage.ToString();
        }


        switch (stats.turretName)
        {
            case "AutoTurret":
                damageBonus.text = "+" + GameMechanics.Mechanics.AutoUpgradeDamage.ToString();
                radiusBonus.text = "+" + GameMechanics.Mechanics.AutoUpgradeRadius.ToString();
                break;
            case "Machinegun":
                damageBonus.text = "+" + GameMechanics.Mechanics.MachinegunUpgradeDamage.ToString();
                radiusBonus.text = "+" + GameMechanics.Mechanics.MachinegunUpgradeRadius.ToString();
                break;
            case "Sniper":
                damageBonus.text = "+" + GameMechanics.Mechanics.SniperUpgradeDamage;
                radiusBonus.text = "+" + GameMechanics.Mechanics.SniperUpgradeRadius;
                break;
            case "Louncher":
                damageBonus.text = "+" + GameMechanics.Mechanics.LouncherUpgradeDamage;
                radiusBonus.text = "+" + GameMechanics.Mechanics.LouncherUpgradeRadius;
                break;
            case "Flamer":
                damageBonus.text = "+" + GameMechanics.Mechanics.FlamerUpgradeDamage;
                break;
            case "IceTurret":
                damageBonus.text = "-" + GameMechanics.Mechanics.IceTurretUpgradeSlow;
                break;
        }


        

    }

    void WhoSelect()
    {
        Unselect();
        switch(turret.GetComponent<TargetingSystem>().method)
        {
            case "First":
                targetingButtonsSelection[0].color = new Color(1, 1, 1, 1);
                break;
            case "Lastone":
                targetingButtonsSelection[1].color = new Color(1, 1, 1, 1);
                break;
            case "Weakest":
                targetingButtonsSelection[2].color = new Color(1, 1, 1, 1);
                break;
            case "Strongest":
                targetingButtonsSelection[3].color = new Color(1, 1, 1, 1);
                break;
            case "Nearest":
                targetingButtonsSelection[4].color = new Color(1, 1, 1, 1);
                break;
            case "Random":
                targetingButtonsSelection[5].color = new Color(1, 1, 1, 1);
                break;
        }
    }
}
