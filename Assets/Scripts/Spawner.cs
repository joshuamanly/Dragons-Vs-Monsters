using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //list of towers [prefabs] that will initiate
    public List<GameObject> towersPrefabs;
    //Transform of spawning towers [root object]
    public Transform spawnTowerRoot;
    //list of tower [UI]
    public List<Image> towersUI;

    //id of tower
    int spawnID = -1;
    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;

    void Update() { 
        if (CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
        {
            return false;
        }
        else
            return true;
    }
    void DetectSpawnPoint()
    {
        //detect when mouse is clicked[first touch clicked]
        if (Input.GetMouseButtonDown(0))
        {
            
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //check if we can spawn in that cell [collider]
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost(spawnID);
                //check if the mana is enough to spawn
                if(GameManager.instance.manaHandler.EnoughMana((float)towerCost))
                {
                    //use the amount of cost to reduce the mana
                    GameManager.instance.manaHandler.ReduceMana((float)towerCost);
                    //spawn the tower
                    SpawnTower(cellPosCentered);
                    //disable the collider
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("Not enough mana");    
                }
            }
        }
    }   

    public int TowerCost(int id)
    {
        switch(id)
        {
            case 0: return towersPrefabs[0].GetComponent<FireDragon>().cost;
            case 1: return towersPrefabs[1].GetComponent<EarthDragon>().cost;
            case 2: return towersPrefabs[2].GetComponent<ManaDragonSc>().cost;
            case 3: return towersPrefabs[3].GetComponent<MetalDragon>().cost;
            default: return -1;
        }
    }

    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        DeselectTowers();
    }
    public void SelectTower(int id)
    {
        DeselectTowers();
        
        //set the spawn ID
        spawnID = id;
        //hightlight the tower
        towersUI[spawnID].color = Color.white;
    }

    public void DeselectTowers()
    {
        spawnID = -1;
        foreach(var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
       
    }
}