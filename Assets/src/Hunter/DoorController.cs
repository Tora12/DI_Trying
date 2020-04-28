using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 teleportLocation;

    public void openDoor(int delay)
    {
        StartCoroutine(openDoor_Coroutine(delay));
    }

    IEnumerator openDoor_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponentInChildren<Animation>().Play("open");
    }

    public void closeDoor(int delay)
    {
        StartCoroutine(closeDoor_Coroutine(delay));
    }

    IEnumerator closeDoor_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponentInChildren<Animation>().Play("close");
    }
}