using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public string method;
    List<GameObject> enemies;
    //public Tower tower;
    public GameObject target;

    private void Start()
    {
        enemies = new List<GameObject>();
    }


    private void FixedUpdate()
    {
        if (target == null)
            FindNewTarget();
    }



    private void OnTriggerEnter (Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
            if (enemies.Count == 1)
                target = collision.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            for (int i = 0; i < enemies.Count; i++)
                if (collision.gameObject == enemies[i])
                    enemies.RemoveAt(i);
            if (collision.gameObject == target)
                FindNewTarget();
        }
    }


    void FindNewTarget()
    {
        ClearList();
        if (enemies.Count == 1)
            target = enemies[0];
        else
        if (enemies.Count != 0)
        {
            switch (method)
            {
                case "First":
                    target = enemies[0];
                    break;
                case "Lastone":
                    target = enemies[enemies.Count - 1];
                    break;
                case "Weakest":
                    Weakest();
                    break;
                case "Strongest":
                    Strongest();
                    break;
                case "Nearest":
                    Nearest();
                    break;
                case "Random":
                    target = enemies[Random.Range(0, enemies.Count)];
                    break;
                default:
                    target = enemies[0];
                    break;
            }
            
        }
        else
        {
            target = null;
        }
    }




    void Weakest()
    {
        int heatPoint = 10000;
        for (int i = 0; i < enemies.Count; i++)
        {
            int hp = enemies[i].GetComponent<Enemy>().heatPoint;
            if (heatPoint > hp)
            {
                heatPoint = hp;
                target = enemies[i];
            }
        }
    }

    void Strongest()
    {
        int heatPoint = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            int hp = enemies[i].GetComponent<Enemy>().heatPoint;
            if (heatPoint < hp)
            {
                heatPoint = hp;
                target = enemies[i];
            }
        }
    }


    void Nearest()
    {
        Vector2 myPos = this.transform.position;
        Vector2 creepPos;
        float lowMagnitude = 1000;
        for (int i = 0; i < enemies.Count; i++)
        {
            creepPos = enemies[i].transform.position;
            if (lowMagnitude > (myPos - creepPos).magnitude)
            {
                lowMagnitude = (myPos - creepPos).magnitude;
                target = enemies[i];
            }
        }
    }


    void ClearList()
    {
        for (int i = enemies.Count; i > 0; i--)
        {
            if (enemies[i - 1] == null)
                enemies.RemoveAt(i - 1);
        }
    }

}
