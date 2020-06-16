using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamer : MonoBehaviour
{
    public TargetingSystem targeting;
    

    int turretLevel = 1;
    float timeToShut;
    int damage;
    int upgradeDamage;
    SphereCollider targetRadius;
    float upgradeRadius;
    TurretStats turStats;

    public ParticleSystem flame1;
    public ParticleSystem flame2;
    public GameObject flameBullet;

    public GameObject targetRadiusCorrent;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = GameObject.Find("GameEngine").GetComponent<GameEngine>().soundEffectVolume;
        targetRadius = GetComponent<SphereCollider>();
        turStats = GetComponent<TurretStats>();
        damage = GameMechanics.Mechanics.FlamerDamage;
        upgradeDamage = GameMechanics.Mechanics.FlamerUpgradeDamage;
        upgradeRadius = GameMechanics.Mechanics.FlamerUpgradeRadius;
        RestatusStats();
    }


    private void FixedUpdate()
    {
        if (targeting.target != null)
        {
            Vector3 facerotation = targeting.target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(facerotation);
            //Rotation
            if (GameMechanics.Mechanics.turretsRotation)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * GameMechanics.Mechanics.BonusTurretRotation);
            else
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * GameMechanics.Mechanics.RotationSpeed);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (RotationTargeting())
                Fire();
        }
        timeToShut -= Time.deltaTime;
    }


    void Fire()
    {
        if (timeToShut < 0)
        {
            source.Play();
            FlameBulletFire();
            timeToShut = GameMechanics.Mechanics.FlamerReloatTime;
            flame1.Play();
            flame2.Play();
        }
    }

    public void Upgrade()
    {
        if (turretLevel != GameMechanics.Mechanics.MaxTowerLvl)
        {
            turretLevel += 1;
            damage += upgradeDamage;
            RestatusStats();
        }
    }

    public void ShowRadius(bool show)
    {
        targetRadiusCorrent.SetActive(show);
    }

    public void ShowRadiusPlus(bool show)
    {
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


    void FlameBulletFire()
    {
        GameObject bullet = Instantiate(flameBullet, flame1.gameObject.transform.position, Quaternion.identity);
        
        float cosMoving = Mathf.Cos(this.transform.eulerAngles.y / 180 * Mathf.PI);
        float sinMoving = Mathf.Sin(this.transform.eulerAngles.y / 180 * Mathf.PI);
        //Moving
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(sinMoving * GameMechanics.Mechanics.FlamerBulletSpeed, 0, cosMoving * GameMechanics.Mechanics.FlamerBulletSpeed);

        FlameBullet bullatIn = bullet.GetComponent<FlameBullet>();

        if(GameMechanics.Mechanics.flameDamage)
            bullatIn.damage = damage + GameMechanics.Mechanics.BonusFlameDamage;
        else
            bullatIn.damage = damage;
        if(GameMechanics.Mechanics.burningTime)
            bullatIn.burningTime = GameMechanics.Mechanics.FlamerBurningTime + GameMechanics.Mechanics.BonusBurningTime;
        else
            bullatIn.burningTime = GameMechanics.Mechanics.FlamerBurningTime;


        bullatIn.lifeTime = GameMechanics.Mechanics.FlamerBulletLifeTime;
        bullatIn.RadiusModification = GameMechanics.Mechanics.FlamerRadiusModification;
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
