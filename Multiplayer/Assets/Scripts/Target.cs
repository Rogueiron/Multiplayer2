using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float health = 50f;
    private Alteruna.Avatar avatar;


    private void Start()
    {
        avatar = GetComponent<Alteruna.Avatar>();
    }

    public void takeDamage(float amount)
    {
        if (!avatar.IsMe)
        {
            return;
        }
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
