using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float slowSpeed;
    public float burningTime;

    float time;
    public float lifeTime;
    public float RadiusModification;
    public SphereCollider sphere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.SendMessage("Freeze", slowSpeed);
            other.gameObject.SendMessage("HowLongToFreeze", burningTime);
        }
    }

    private void FixedUpdate()
    {
       // transform.localScale = new Vector3(time * RadiusModification, time * RadiusModification, time * RadiusModification);
        sphere.radius = time * RadiusModification;
        time += Time.deltaTime;
        if (time > lifeTime)
            Destroy(this.gameObject);
    }
}
