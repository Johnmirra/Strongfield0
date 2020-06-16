using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : MonoBehaviour
{
    public int damage;
    public float burningTime;

    float time;
    public float lifeTime;
    public float RadiusModification;
    public SphereCollider sphere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.SendMessage("StartBurn", damage);
            other.gameObject.SendMessage("HowLongToBurn", burningTime);
        }
    }

    private void FixedUpdate()
    {
        //transform.localScale = new Vector3(time* RadiusModification, time * RadiusModification, time * RadiusModification);
        sphere.radius = time * RadiusModification;
        time += Time.deltaTime;
        if (time > lifeTime)
            Destroy(this.gameObject);
    }
}
