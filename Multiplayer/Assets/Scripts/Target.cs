using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class Target : AttributesSync
{
    [SynchronizableField] private float health = 50f;
    private Spawner spawner;
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

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
        spawner.Despawn(gameObject);
    }
}
