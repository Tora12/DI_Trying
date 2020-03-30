using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameTriggers gameTriggers;
    [SerializeField] private GameObject[] enemyArray;
    [SerializeField] private float min = 0.0f;
    [SerializeField] private float max = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        spawn = new Vector3(0.0f, 0.5f, Random.Range(min, max));
        gameTriggers.spawnEntity(enemyArray[num], spawn, 0);
    }
}
