using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        if (GameMechanics.Mechanics.explRadius)
            this.transform.localScale = new Vector3(GameMechanics.Mechanics.BonusLouncherExplRadius, GameMechanics.Mechanics.BonusLouncherExplRadius, GameMechanics.Mechanics.BonusLouncherExplRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.gameObject.SendMessage("TakeDamage", damage);
    }
}
