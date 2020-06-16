using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTree : MonoBehaviour
{
    [Header("Bunuses connection")]
    public string bonus1;
    public string bonus2;

    [Header("Activate buttons")]
    public Image OpenButton1;
    public Image OpenButton2;
    public Image OpenButton3;

    [Header("Else stuf")]
    public string myName;
    public bool OpenedButton;
    public GameObject _BonusActivatedButton;
    public GameObject _activeteScreen;
    public Text _discription;
    public Image _myImage;
    bool _iAmActive;


    
    private void Start()
    {
        _activeteScreen.SetActive(false);
    }

    public void Push()
    {
        
        _discription.text = TextCompilation(myName);
        _activeteScreen.SetActive(true);

        if(GameEngine.Engine.coins < GameMechanics.Mechanics.BonusCost)
            _BonusActivatedButton.SendMessage("UnActiveButton");
        else
        if (myName == "AutoTurret" || _iAmActive)
            _BonusActivatedButton.SendMessage("UnActiveButton");
        else
        if (Switcher(bonus1) || Switcher(bonus2) || OpenedButton)
        {
            //open activated screen
            _BonusActivatedButton.SendMessage("SelectTreeButton", this.gameObject);
        }
        else
        {
            _BonusActivatedButton.SendMessage("UnActiveButton");
            //block avtivate button
        }
    }

    public void Activete()
    {
        _myImage.color = new Color(1f, 0.5f, 0f);

        if (OpenButton1 != null && OpenButton1.color != new Color(1f, 0.5f, 0f))
            OpenButton1.color = new Color(1, 1, 1);
        if (OpenButton2 != null && OpenButton1.color != new Color(1f, 0.5f, 0f))
            OpenButton2.color = new Color(1, 1, 1);
        if (OpenButton3 != null && OpenButton1.color != new Color(1f, 0.5f, 0f))
            OpenButton3.color = new Color(1, 1, 1);

        _iAmActive = true;
        ActivateByName(myName);
        _activeteScreen.SetActive(false);
    }



    void ActivateByName(string name)
    {
        switch (name)
        {
            case "Sniper":
                GameMechanics.Mechanics.sniper = true;
                break;
            case "Machinegun":
                GameMechanics.Mechanics.machinegun = true;
                break;
            case "Damage":
                GameMechanics.Mechanics.damage = true;
                break;
            case "TurretsRotation":
                GameMechanics.Mechanics.turretsRotation = true;
                break;
            case "Radius":
                GameMechanics.Mechanics.radius = true;
                break;
            case "TurratesFR":
                GameMechanics.Mechanics.turretsFR = true;
                break;
            case "Flamer":
                GameMechanics.Mechanics.flamer = true;
                break;
            case "BurningTime":
                GameMechanics.Mechanics.burningTime = true;
                break;
            case "FlameRadius":// flameRadius it is flameDamage!
                GameMechanics.Mechanics.flameDamage = true;
                break;
            case "IceTurret":
                GameMechanics.Mechanics.iceTurret = true;
                break;
            case "FreezeTime":
                GameMechanics.Mechanics.freezeTime = true;
                break;
            case "SlowingSpeed":
                GameMechanics.Mechanics.slowingSpeed = true;
                break;
            case "Louncher":
                GameMechanics.Mechanics.louncher = true;
                break;
            case "RLRadius":
                GameMechanics.Mechanics.rlRadius = true;
                break;
            case "LouncherFR":
                GameMechanics.Mechanics.louncherFR = true;
                break;
            case "ExplRadius":
                GameMechanics.Mechanics.explRadius = true;
                break;
        }
    }

    bool Switcher(string name)
    {
        bool cheker = false;
        switch (name)
        {
            case "Sniper":
                cheker = GameMechanics.Mechanics.sniper;
                break;
            case "Machinegun":
                cheker = GameMechanics.Mechanics.machinegun;
                break;
            case "Damage":
                cheker = GameMechanics.Mechanics.damage;
                break;
            case "TurretsRotation":
                cheker = GameMechanics.Mechanics.turretsRotation;
                break;
            case "Radius":
                cheker = GameMechanics.Mechanics.radius;
                break;
            case "TurratesFR":
                cheker = GameMechanics.Mechanics.turretsFR;
                break;
            case "Flamer":
                cheker = GameMechanics.Mechanics.flamer;
                break;
            case "BurningTime":
                cheker = GameMechanics.Mechanics.burningTime;
                break;
            case "FlameRadius"://its flame damage!
                cheker = GameMechanics.Mechanics.flameDamage;
                break;
            case "IceTurret":
                cheker = GameMechanics.Mechanics.iceTurret;
                break;
            case "FreezeTime":
                cheker = GameMechanics.Mechanics.freezeTime;
                break;
            case "SlowingSpeed":
                cheker = GameMechanics.Mechanics.slowingSpeed;
                break;
            case "Louncher":
                cheker = GameMechanics.Mechanics.louncher;
                break;
            case "RLRadius":
                cheker = GameMechanics.Mechanics.rlRadius;
                break;
            case "LouncherFR":
                cheker = GameMechanics.Mechanics.louncherFR;
                break;
            case "ExplRadius":
                cheker = GameMechanics.Mechanics.explRadius;
                break;
        }
        return (cheker);
    }

    string TextCompilation(string name)
    {
        string text = "";
        switch (name)
        {
            case "AutoTurret":
                text = "Auto turret. Simple turret. Has small damage attack. Cost - 200";
                break;
            case "Sniper":
                text = "Sniper turret. Best fire range turret. Also make alote of damage per shut. Cost - 200";
                break;
            case "Machinegun":
                text = "Machingun turret. it's very powerfull turret. Have big rate of fire. Effective against all type of enemys. Cost - 200";
                break;
            case "Damage":
                text = "Increases damage of AutoTurret, Sniper and Machinegun turret. Cost - 200";
                break;
            case "TurretsRotation":
                text = "Increse turret rotation speed. Cost - 200";
                break;
            case "Radius":
                text = "Increase turret target range radius. Cost - 200";
                break;
            case "TurratesFR":
                text = "Inscrese fire rate of bullet type turrets. Cost - 200";
                break;
            case "Flamer":
                text = "Flamer turret. The turret has a small attack radius but high damage at an increased turret level. Cost - 200";
                break;
            case "BurningTime":
                text = "Increase enemy burning time. Cost - 200";
                break;
            case "FlameRadius":
                text = "Increse damage of flame turret. Cost - 200";
                break;
            case "IceTurret":
                text = "Ice turret. Can freezing enemy speed. Cost - 200";
                break;
            case "FreezeTime":
                text = "Increase duration of enemy freezing. Cost - 200";
                break;
            case "SlowingSpeed":
                text = "Increase power of enemy slowing down. Cost - 200";
                break;
            case "Louncher":
                text = "Rocket Louncher turret. Have splash damage, can at the same time hit few nemeys. Cost - 200";
                break;
            case "RLRadius":
                text = "Increase louncher radius atack. Cost - 200";
                break;
            case "LouncherFR":
                text = "Increase fire rate of lounchers. Cost - 200";
                break;
            case "ExplRadius":
                text = "Increase explosion radius if rocket. Cost - 200";
                break;
        }
        return (text);
    }
}
