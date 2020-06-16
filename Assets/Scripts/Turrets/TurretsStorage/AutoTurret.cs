﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public TargetingSystem targeting;
    
    Rigidbody rBody;

    int turretLevel = 1;
    float timeToShut;
    int damage;
    int upgradeDamage;
    SphereCollider targetRadius;
    float upgradeRadius;
    TurretStats turStats;
    public GameObject barrel;
    public GameObject bullet;
    bool chekBonusRadiusIsGet;

    public GameObject targetRadiusCorrent;
    public GameObject targetRadiusPlus;

    AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        if (GameObject.Find("GameEngine").GetComponent<GameEngine>().soundEffectVolume > 0.2f)
            source.volume = GameObject.Find("GameEngine").GetComponent<GameEngine>().soundEffectVolume - 0.2f;
        targetRadius = GetComponent<SphereCollider>();
        rBody = GetComponent<Rigidbody>();
        turStats = GetComponent<TurretStats>();
        damage = GameMechanics.Mechanics.AutoDamage;
        upgradeDamage = GameMechanics.Mechanics.AutoUpgradeDamage;
        upgradeRadius = GameMechanics.Mechanics.AutoUpgradeRadius;
        RestatusStats();
    }


    private void FixedUpdate()
    {
        if (targeting.target != null)
        {
            Vector3 facerotation = targeting.target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(facerotation);
            //Rotation
            if(GameMechanics.Mechanics.turretsRotation)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * GameMechanics.Mechanics.BonusTurretRotation);
            else
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * GameMechanics.Mechanics.RotationSpeed);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if(RotationTargeting())
                Fire();
        }
        timeToShut -= Time.deltaTime;

        if (!chekBonusRadiusIsGet)
            if (GameMechanics.Mechanics.rlRadius)
            {
                chekBonusRadiusIsGet = true;
                targetRadius.radius *= GameMechanics.Mechanics.BonusTurretTurretRadius;
                targetRadiusCorrent.transform.localScale *= GameMechanics.Mechanics.BonusLouncherRadius;
            }
    }


    void Fire()
    {
        if (timeToShut < 0)
        {
            source.clip = clip;
            source.pitch = Random.Range(0.9f, 1.1f);
            source.Play();
            if (GameMechanics.Mechanics.turretsFR)
                timeToShut = GameMechanics.Mechanics.AutoTurretReloatTime * GameMechanics.Mechanics.BonusTurretFR;
            else
                timeToShut = GameMechanics.Mechanics.AutoTurretReloatTime;
            GameObject myBullet = (GameObject)Instantiate(bullet, barrel.transform.position, Quaternion.identity);
            myBullet.SendMessage("Shut", targeting.target);
            if (GameMechanics.Mechanics.damage)
                targeting.target.SendMessage("TakeDamage", damage + GameMechanics.Mechanics.BonusDamageToAutoTurret);
            else
                targeting.target.SendMessage("TakeDamage", damage);
            Debug.DrawLine(barrel.transform.position, targeting.target.transform.position);
        }
    }

    public void Upgrade()
    {
        turretLevel += 1;
        damage += upgradeDamage;
        targetRadius.radius *= upgradeRadius;
        targetRadiusCorrent.transform.localScale *= upgradeRadius;
        RestatusStats();
    }
    public void ShowRadius(bool show)
    {
        targetRadiusCorrent.SetActive(show);
    }

    public void ShowRadiusPlus(bool show)
    {
        if (show)
            targetRadiusPlus.transform.localScale = targetRadiusCorrent.transform.localScale * upgradeRadius;
        targetRadiusPlus.SetActive(show);
    }

    void RestatusStats()
    {
        turStats.towerLevel = turretLevel;
        turStats.Damage = damage;//plus bonus!!!!!!!!!!!!!!!!!!!!!
        turStats.radius = targetRadius.radius;
    }



    bool RotationTargeting()
    {
        bool _myChek = false;

        Vector3 pointPos = targeting.target.transform.position;
        Vector3 botPos = this.transform.position;

        Vector3 magnitude = pointPos - botPos;
        float towerAngl = 360 - this.transform.eulerAngles.y;
        float anglBetween;
        float pointAngl = AnglMath(magnitude);


        anglBetween = pointAngl - towerAngl;
        if (pointAngl > towerAngl)
        {
            anglBetween = pointAngl - towerAngl;
            if (anglBetween > 180)
                anglBetween = 360 - pointAngl + towerAngl;
        }
        else
        {
            anglBetween = towerAngl - pointAngl;
            if (anglBetween > 180)
                anglBetween = 360 - towerAngl + pointAngl;
        };
        if (anglBetween < GameMechanics.Mechanics.anglOfFire)
            _myChek = true;


        return (_myChek);
    }

    float AnglMath(Vector3 anglChek)
    {
        float angl = Mathf.Asin(anglChek.x / anglChek.magnitude) * 180 / Mathf.PI;

        if (anglChek.z > 0 && anglChek.x < 0)
            angl = -angl;

        if (anglChek.z <= 0 && anglChek.x <= 0)
            angl = 180 + angl;

        if (anglChek.z < 0 && anglChek.x > 0)
            angl = 180 + angl;

        if (anglChek.z >= 0 && anglChek.x >= 0)
            angl = 360 - angl;

        return angl;
    }
}
