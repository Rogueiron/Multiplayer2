using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class Target : AttributesSync
{
    private float health = 50f;
    private Spawner spawner;
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
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
