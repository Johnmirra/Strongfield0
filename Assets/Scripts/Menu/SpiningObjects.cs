using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningObjects : MonoBehaviour
{
    public Transform CreepPlace, TowerPlace;
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject tower4;
    public GameObject tower5;
    public GameObject tower6;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    private Rigidbody _rBodyCreep, _rBodyTower;
    private GameObject tower;


    void Awake()
    {
        switch(Random.Range(1,5))
        {
            case 1:
                _rBodyCreep = Instantiate(Enemy1, CreepPlace.position, Quaternion.identity).GetComponent<Rigidbody>();
                break;
            case 2:
                _rBodyCreep = Instantiate(Enemy2, CreepPlace.position, Quaternion.identity).GetComponent<Rigidbody>();
                break;
            case 3:
                _rBodyCreep = Instantiate(Enemy3, CreepPlace.position, Quaternion.identity).GetComponent<Rigidbody>();
                break;
            case 4:
                _rBodyCreep = Instantiate(Enemy4, CreepPlace.position, Quaternion.identity).GetComponent<Rigidbody>();
                break;
        }
        
        switch(Random.Range(1,7))
        {
            case 1:
                tower = Instantiate(tower1, TowerPlace.position, Quaternion.identity);
                break;
            case 2:
                tower = Instantiate(tower2, TowerPlace.position, Quaternion.identity);
                break;
            case 3:
                tower = Instantiate(tower3, TowerPlace.position, Quaternion.identity);
                break;
            case 4:
                tower = Instantiate(tower4, TowerPlace.position, Quaternion.identity);
                break;
            case 5:
                tower = Instantiate(tower5, TowerPlace.position, Quaternion.identity);
                break;
            case 6:
                tower = Instantiate(tower6, TowerPlace.position, Quaternion.identity);
                break;
            
        }

        _rBodyCreep.gameObject.GetComponent<Enemy>().enabled = false;
        _rBodyCreep.gameObject.GetComponent<Burning>().enabled = false;


        _rBodyTower = tower.AddComponent<Rigidbody>();
        _rBodyTower.useGravity = false;
        StopTurretsScript(_rBodyTower.gameObject);
    }

    private void Update()
    {
        _rBodyCreep.angularVelocity = new Vector3(0f, 0.4f, 0f);
        _rBodyTower.angularVelocity = new Vector3(0f, -0.7f, 0f);
    }


    void StopTurretsScript(GameObject turret)
    {
        switch(turret.tag)
        {
            case "AutoTurret":
                turret.GetComponent<AutoTurret>().enabled = false;
                break;
            case "Machinegun":
                turret.GetComponent<Machinegun>().enabled = false;
                break;
            case "Sniper":
                turret.GetComponent<Sniper>().enabled = false;
                break;
            case "Flamer":
                turret.GetComponent<Flamer>().enabled = false;
                break;
            case "Iceturret":
                turret.GetComponent<IceTurret>().enabled = false;
                break;
            case "Louncher":
                turret.GetComponent<Louncher>().enabled = false;
                break;
        }
    }
}
