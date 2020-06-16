using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string myName;
    GameMechanics _mechanics;
    public int heatPoint;
    Rigidbody rBody;
    public Transform _chekpoint;
    float speed;
    public float freezeSpeed = 1f;
    float timeFreeze = 0;
    public GameObject explosion;

    private void Start()
    {
        _mechanics = GameObject.Find("GameEngine").GetComponent<GameMechanics>();

        rBody = GetComponent<Rigidbody>();

        switch (myName)
        {
            case "Frigate":
                speed = _mechanics.frigateSpeed;
                break;
            case "Fighter":
                speed = _mechanics.fighterSpeed;
                break;
            case "Bomber":
                speed = _mechanics.bomberSpeed;
                break;
            case "MotherShip":
                speed = _mechanics.motherShipSpeed;
                break;
        }
    }

    private void FixedUpdate()
    {
        float cosMoving = Mathf.Cos(transform.eulerAngles.y / 180 * Mathf.PI);
        float sinMoving = Mathf.Sin(transform.eulerAngles.y / 180 * Mathf.PI);
        //Moving
        rBody.velocity = new Vector3(sinMoving * speed* freezeSpeed, 0, cosMoving * speed * freezeSpeed);
        ///Debug.Log(freezeSpeed);

        Vector3 facerotation = _chekpoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(facerotation);
        //Rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);

        if (freezeSpeed != 1f && timeFreeze < 0)
            UnFreeze();
        else
            timeFreeze -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chekpoint")
        {
            _chekpoint = other.GetComponent<Chekpoints>()._chekpoint;
        }
        if (other.tag == "Base")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameEngine.Engine.LiveMinus();
            Destroy(this.gameObject);
        }
    }

    public void Freeze(float slowSpeed)
    {
        freezeSpeed = slowSpeed;
    }

    public void UnFreeze()
    {
        freezeSpeed = 1;
    }
    public void HowLongToFreeze(float timeFr)
    {
        timeFreeze = timeFr;
    }


    public void TakeDamage(int damage)
    {
        heatPoint -= damage;
        if (heatPoint <= 0)
        {
            switch (myName)
            {
                case "Frigate":
                    GameEngine.Engine.coins += GameMechanics.Mechanics.rewardFrigate;
                    break;
                case "Fighter":
                    GameEngine.Engine.coins += GameMechanics.Mechanics.rewardFighter;
                    break;
                case "Bomber":
                    GameEngine.Engine.coins += GameMechanics.Mechanics.rewardBomber;
                    break;
                case "MotherShip":
                    GameEngine.Engine.coins += GameMechanics.Mechanics.rewardMothership;
                    break;
            }
            
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
