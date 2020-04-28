using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTriggers : MonoBehaviour
{
    public void spawnEntity(GameObject entity, Vector3 location, int delay)
    {
        StartCoroutine(spawnEntity_Coroutine(entity, location, delay));
    }

    IEnumerator spawnEntity_Coroutine(GameObject entity, Vector3 location, int delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(entity, location, Quaternion.identity);
    }

    public void despawnEntity(GameObject entity, int delay)
    {
        StartCoroutine(despawnEntity_Coroutine(entity, delay));
    }

    IEnumerator despawnEntity_Coroutine(GameObject entity, int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(entity);
    }

    public void respawnPlayer(GameObject player, Vector3 location, int delay)
    {
        StartCoroutine(respawnPlayer_Coroutine(player, location, delay));
    }

    IEnumerator respawnPlayer_Coroutine(GameObject player, Vector3 location, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerHealthandDamage>().respawnPlayer();
        player.transform.position = location;
    }

    public void despawnPlayer(GameObject player, int delay)
    {
        StartCoroutine(despawnPlayer_Coroutine(player, delay));
    }

    IEnumerator despawnPlayer_Coroutine(GameObject player, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.SetActive(false);
    }

    public void enterRegion(GameObject player, Vector3 location, int[] temp, int delay)
    {
        StartCoroutine(enterRegion_Coroutine(player, location, temp, delay));
    }

    IEnumerator enterRegion_Coroutine(GameObject player, Vector3 location, int[] temp, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
    }
}
