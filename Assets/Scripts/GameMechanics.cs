using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics Mechanics;

    [Header("All turrets balance")]
    public int MaxTowerLvl;
    public float RotationSpeed;
    public float BonusRotationSpeed;
    public float anglOfFire;

    [Header("AutoTurret")]
    public float AutoTurretReloatTime;
    public int AutoDamage;
    public int AutoUpgradeDamage;
    public float AutoUpgradeRadius;

    [Header("Machinegun")]
    public float MachinegunReloatTime;
    public int MachinegunDamage;
    public int MachinegunUpgradeDamage;
    public float MachinegunUpgradeRadius;

    [Header("Sniper")]
    public float SniperReloatTime;
    public int SniperDamage;
    public int SniperUpgradeDamage;
    public float SniperUpgradeRadius;

    [Header("Louncher")]
    public float LouncherReloatTime;
    public int LouncherDamage;
    public int LouncherUpgradeDamage;
    public float LouncherUpgradeRadius;

    [Header("Flamer")]
    public float FlamerReloatTime;
    public int FlamerDamage;
    public int FlamerUpgradeDamage;
    public float FlamerBurningTime;
    public float FlamerUpgradeRadius;
    public float FlamerBulletLifeTime;
    public float FlamerRadiusModification;
    public float FlamerBulletSpeed;

    [Header("IceTurret")]
    public float IceTurretReloatTime;
    public float IceTurretSlowSpeed;
    public int IceTurretUpgradeSlow;
    public float IceTurretUpgradeRadius;
    public float IceBurningTime;
    public float IceUpgradeRadius;
    public float IceBulletLifeTime;
    public float IceRadiusModification;
    public float IceBulletSpeed;


    [Header("Enemy balance")]
    //public int HP;
    public float frigateSpeed;
    public float fighterSpeed;
    public float bomberSpeed;
    public float motherShipSpeed;
    

    [Header("Cost for everything")]
    public int BonusCost;
    public int rewardMothership;
    public int rewardBomber;
    public int rewardFighter;
    public int rewardFrigate;
    public int turretSellReward;
    public int upAutoturret;
    public int upMachinegun;
    public int upSniper;
    public int upLouncher;
    public int upFlamer;
    public int upIceTurret;
    public int costAutoturret;
    public int costMachinegun;
    public int costSniper;
    public int costLouncher;
    public int costFlamer;
    public int costIceTurret;

    [Header("Bonus Tree")]
    public bool sniper;
    public bool machinegun;
    public bool damage;
    public bool turretsRotation;
    public bool radius;
    public bool turretsFR;
    public bool flamer;
    public bool burningTime;
    public bool flameDamage;
    public bool iceTurret;
    public bool freezeTime;
    public bool slowingSpeed;
    public bool louncher;
    public bool rlRadius;
    public bool louncherFR;
    public bool explRadius;

    [Header("Bonuses to turrets")]
    public int BonusDamageToAutoTurret;
    public int BonusDamageToSniper;
    public int BonusDamageToMachinegun;
    public float BonusTurretRotation;
    public float BonusTurretTurretRadius;
    public float BonusSniperRadius;
    public float BonusTurretFR;

    [Header("Bonus for Flamers")]
    public int BonusFlameDamage;
    public float BonusBurningTime;
    public float BonusFreezeTime;
    public float BonusSlowingSpeed;

    [Header("Bonus for Lounchers")]
    public float BonusLouncherRadius;
    public float BonusLouncherFR;
    public float BonusLouncherExplRadius;

    private void Awake()
    {
        Mechanics = this;
    }
}
