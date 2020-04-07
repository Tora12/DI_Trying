using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameTriggers gameTriggers;
    [SerializeField] private GameObject[] enemyArray;
    [SerializeField] private float minSpawnArea = 0.0f;
    [SerializeField] private float maxSpawnArea = 0.0f;
    public int minEnemyCount = 0;
    public int maxEnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        int max = Random.Range(minEnemyCount, maxEnemyCount);
        for (int i = 0; i < max; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int enemyCount = enemyArray.Length;
        int num = Random.Range(0, enemyCount);
        Vector3 spawn;
        spawn = new Vector3(0.0f, 0.5f, Random.Range(minSpawnArea, maxSpawnArea));
        gameTriggers.spawnEntity(enemyArray[num], spawn, 0);
    }
}
