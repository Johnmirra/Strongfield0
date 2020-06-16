using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    
    public ParticleSystem psFlame;
    int DamagePerSecond;
    float time;
    float burningTime;

    

    public void HowLongToBurn(float newTime)
    {
        burningTime = newTime;
    }

    public void StartBurn(int damPerSec)
    {
        DamagePerSecond += damPerSec;
        psFlame.loop = true;
        psFlame.Play();
        this.gameObject.SendMessage("UnFreeze");
    }

    public void StopBurning()
    {
        DamagePerSecond = 0;
        psFlame.loop = false;
    }

    private void FixedUpdate()
    {
        if (time < 0)
        {
            time = 1;
            this.gameObject.SendMessage("TakeDamage", DamagePerSecond);
        }
        else
            time -= Time.deltaTime;


        burningTime -= Time.deltaTime;
        if (burningTime <= 0)
            StopBurning();
    }
}
