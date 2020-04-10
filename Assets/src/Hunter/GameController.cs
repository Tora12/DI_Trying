using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public int[] temp;
    
    [SerializeField] private GameTriggers gameTriggers;

    void Start()
    {
        //       Vector3 test = new Vector3(-0.058f, 0.51f, -90f);
        //       gameTriggers.enterRoom(player, test, temp, 5);

        Rigidbody rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Door")
        {
            DoorController doorController = col.GetComponent<DoorController>();
            gameTriggers.enterRoom(player, doorController.teleportLocation, temp, 1);
        }
    }
}
