using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Numbers")]
    public GameObject[] enemyArray;
    public float minSpawnArea = 0.0f;
    public float maxSpawnArea = 0.0f;
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

    public void Spawn()
    {
        int enemyCount = enemyArray.Length;
        int num = Random.Range(0, enemyCount);
        Vector3 spawn;
        spawn = new Vector3(0.0f, 0.5f, Random.Range(minSpawnArea, maxSpawnArea));
        GameManager.Instance.spawnEntity(enemyArray[num], spawn, Quaternion.identity, 0);
    }
}
