using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int damage;
    GameObject target = null;
    public float speed;
    Rigidbody rBody;
    public GameObject Explotion;
    float timer = 0.1f;
    bool timerOn;


    public void Shut(GameObject newTarget)
    {
        rBody = GetComponent<Rigidbody>();
        target = newTarget;

        Vector3 facerotation = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(facerotation);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 facerotation = target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(facerotation);

            float cosMoving = Mathf.Cos(transform.eulerAngles.y / 180 * Mathf.PI);
            float yMoving = Mathf.Sin(transform.eulerAngles.z / 180 * Mathf.PI);
            float sinMoving = Mathf.Sin(transform.eulerAngles.y / 180 * Mathf.PI);
            //Moving
            rBody.velocity = new Vector3(sinMoving * speed, yMoving * speed, cosMoving * speed);




            //if (facerotation.magnitude < 5f)
              //  Destroy(this.gameObject);
            //make explosive damage
            //Debug.Log(facerotation.magnitude);
        }
        if(timerOn)
            if (timer < 0)
                Destroy(this.gameObject);
            else
                timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject expl = Instantiate(Explotion, this.transform.position, Quaternion.identity);
            expl.GetComponent<Explosion>().damage = damage;
            timerOn = true;
        }
    }
}
