using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public float checkpointDistance;
    public float sweepTestDistance;
    public int closeDoorDelay;
    public int enterRegionDelay;
    public int finishGameDelay;
    public int respawnPlayerDelay;
    public Vector3 playerStartLocation;
    public Vector3 playerFinishLocation;
    public Vector3[] checkpointLocation;

    void Start()
    {
        GameManager.Instance.checkpointDistance = checkpointDistance;
        GameManager.Instance.sweepTestDistance = sweepTestDistance;
        GameManager.Instance.closeDoorDelay = closeDoorDelay;
        GameManager.Instance.enterRegionDelay = enterRegionDelay;
        GameManager.Instance.finishGameDelay = finishGameDelay;
        GameManager.Instance.respawnPlayerDelay = respawnPlayerDelay;
        GameManager.Instance.playerStartLocation = playerStartLocation;
        GameManager.Instance.playerFinishLocation = playerFinishLocation;
        GameManager.Instance.checkpointLocation = checkpointLocation;
        GameManager.Instance.Start();
    }
}
