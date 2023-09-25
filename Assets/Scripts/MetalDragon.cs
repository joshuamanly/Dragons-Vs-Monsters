using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MetalDragon : Dragon
{
    private int maxHealth;
    
    public GameObject obj_heal;
    public float interval;
    public int healValue;

    protected override void Start()
    {
        maxHealth = health;
        StartCoroutine(Interval());
        
    }
    private void Update()
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseHealth();

        StartCoroutine(Interval());
    }
    public void IncreaseHealth()
    {
        health += healValue;
        StartCoroutine(HealIndication());
    }
    IEnumerator HealIndication()
    {
        obj_heal.SetActive(true);
        yield return new WaitForSeconds(1f);
        obj_heal.SetActive(false);
    }
   
}
