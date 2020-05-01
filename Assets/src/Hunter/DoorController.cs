using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 teleportLocation;

    private IEnumerator closeDoor_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponentInChildren<Animation>().Play("close");
    }
    private IEnumerator openDoor_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponentInChildren<Animation>().Play("open");
    }

    public void closeDoor(int delay)
    {
        StartCoroutine(closeDoor_Coroutine(delay));
    }
    public void openDoor(int delay)
    {
        StartCoroutine(openDoor_Coroutine(delay));
    }
}