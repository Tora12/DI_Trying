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

    public void respawnPlayer(Vector3 location, int delay)
    {
        StartCoroutine(respawnPlayer_Coroutine(location, delay));
    }

    IEnumerator respawnPlayer_Coroutine(Vector3 location, int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    public void despawnPlayer(int delay)
    {
        StartCoroutine(despawnPlayer_Coroutine(delay));
    }

    IEnumerator despawnPlayer_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    public void enterRoom(GameObject player, Vector3 location, int[] temp, int delay)
    {
        StartCoroutine(enterRoom_Coroutine(player, location, temp, delay));
    }

    IEnumerator enterRoom_Coroutine(GameObject player, Vector3 location, int[] temp, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
    }
}
