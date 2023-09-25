using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }
    public Spawner spawner;
    public LifeSystem lifeSystem;
    public ManaHandler manaHandler;
    public GameOverScreen gameOverScreen;
    public SpawnPointsTag spawnPoints;

    void Start()
    {
        GetComponent<LifeSystem>().Init();
        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        //wait for x seconds
        yield return new WaitForSeconds(2f);
        //start the enemy spawning
        GetComponent<EnemySpawner>().StartSpawning();
    }
}
