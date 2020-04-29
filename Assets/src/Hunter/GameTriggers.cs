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

    public void respawnPlayer(GameObject player, GameObject ragDoll, Vector3 location, int delay)
    {
        StartCoroutine(respawnPlayer_Coroutine(player, ragDoll, location, delay));
    }

    IEnumerator respawnPlayer_Coroutine(GameObject player, GameObject ragDoll, Vector3 location, int delay)
    {
        player.SetActive(false);
        player.GetComponent<PlayerController>().Reset();
        spawnEntity(ragDoll, player.transform.position, 0);
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
        despawnEntity(ragDoll, 0);
        player.SetActive(true);
    }

    public void despawnPlayer(GameObject player, GameObject ragDoll, int delay)
    {
        StartCoroutine(despawnPlayer_Coroutine(player, ragDoll, delay));
    }

    IEnumerator despawnPlayer_Coroutine(GameObject player, GameObject ragDoll, int delay)
    {
        yield return new WaitForSeconds(delay);
        
        //despawnEntity(ragDoll, 3);
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
