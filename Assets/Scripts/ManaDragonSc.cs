using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaDragonSc
    : Dragon
{
    //FIELDS
   
    //Income value
    public float incomeValue;
    //interval for income
    public float interval;
    //mana image object
    public GameObject obj_mana;
   

    
    //Methods
    //Init
    protected override void Start()
    {
        StartCoroutine(Interval());
    }
    //Interval IEnumerator
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        //trigger the income increase
        IncreaseIncome();

        StartCoroutine(Interval());
    }
    //trigger income increase
    public void IncreaseIncome()
    {
        GameManager.instance.manaHandler.GainMana(incomeValue);
        StartCoroutine(ManaIndication());
    }
    //show mana indication over the dragon for short time(0.5 s)
    IEnumerator ManaIndication()
    {
        obj_mana.SetActive(true);
        yield return new WaitForSeconds(1f);
        obj_mana.SetActive(false);
    }
    
}
