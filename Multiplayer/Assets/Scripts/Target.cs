using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class Target : AttributesSync
{
    [SynchronizableField] private float health = 50f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
