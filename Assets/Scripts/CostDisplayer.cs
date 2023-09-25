using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
    //fields
    //tower id
    public int towerID;
    //cost value
    public int towerCost;

    
    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text =towerCost.ToString();
    }

}
