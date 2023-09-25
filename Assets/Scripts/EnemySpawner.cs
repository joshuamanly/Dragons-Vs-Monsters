using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    private void Awake() {instance = this; }
    
    //Enemy prefabs
    public List<GameObject> prefabs;
    //enemy spawn root points
    public List<Transform> spawnPoints;
    //enemy spawn interval
    public float spawnInterval = 2f;

    public void StartSpawning()
    {
        //call the spawn couroutine
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        //call the spawn method
        SpawnEnemy();
        //wait spawn interval
        yield return new WaitForSeconds(spawnInterval);
        //recall the same coroutine
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        //Randomize the enemy spawned
        int randomPrefabID = Random.Range(0,prefabs.Count);
        //randomize the spawn point
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        //instantiate the enemy prefab
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
    }
}
