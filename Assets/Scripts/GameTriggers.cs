using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTriggers : MonoBehaviour
{
    public void spawnEntity(GameObject toSpawn, Vector3 location, int delay)
    {
        StartCoroutine(spawnEntity_Coroutine(toSpawn, location, delay));
    }

    IEnumerator spawnEntity_Coroutine(GameObject toSpawn, Vector3 location, int delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(toSpawn, location, Quaternion.identity);
    }

    public void despawnEntity(GameObject toDespawn, int delay)
    {
        StartCoroutine(despawnEntity_Coroutine(toDespawn, delay));
    }

    IEnumerator despawnEntity_Coroutine(GameObject toDespawn, int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(toDespawn);
    }
}
