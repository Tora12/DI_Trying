﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTriggers : MonoBehaviour
{
    public void startGame(GameObject player, Vector3 location, int delay)
    {
        StartCoroutine(startGame_Coroutine(player, location, delay));
    }

    IEnumerator startGame_Coroutine(GameObject player, Vector3 location, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
    }

    public GameObject spawnEntity(GameObject entity, Vector3 location)
    {
        GameObject entityCopy = Instantiate(entity, location, Quaternion.identity);
        return entityCopy;
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
        GameObject ragDollCopy = spawnEntity(ragDoll, player.transform.position);
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
        despawnEntity(ragDollCopy, 0);
        player.SetActive(true);
    }

    public void enterRegion(GameObject player, Vector3 location, int[] AI_Data, int delay)
    {
        StartCoroutine(enterRegion_Coroutine(player, location, AI_Data, delay));
    }

    IEnumerator enterRegion_Coroutine(GameObject player, Vector3 location, int[] AI_Data, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = location;
    }

    public void finishGame(int delay)
    {
        StartCoroutine(finishGame_Coroutine(delay));
    }

    IEnumerator finishGame_Coroutine(int delay)
    {

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu_Scene");
    }
}
