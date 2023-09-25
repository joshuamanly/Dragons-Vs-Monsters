using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : Dragon
{
    //FIELDS
   
    //damage
    public int damage;
    //prefab shooting item
    public GameObject prefab_shootItem;
    //shoot interval
    public float interval;

    //METHODS
    //init start the shooting interval
    protected override void Start()
    {
        //start the shooting interval ienum
        StartCoroutine(ShootDelay());
    }
    //interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());   
           
    }
    //shoot an item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem,transform);
        //set its values
        shotItem.GetComponent<ShootItem>().Init(damage);
        //TODO : create shoot item script
    }
    
    
}
    

