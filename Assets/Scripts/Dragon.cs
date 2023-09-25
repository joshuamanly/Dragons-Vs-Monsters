using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int health, cost;

    protected virtual void Start()
    {
        Debug.Log("BASE TOWER");
    }
    
    public virtual bool LoseHealth(int amount)
    {
        health-= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    protected virtual void Die()
    {
        Debug.Log("dragon is dead");
        Destroy(gameObject);
    }
}
