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
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Door")
        {

            DoorController doorController = col.GetComponent<DoorController>();
            gameTriggers.enterRoom(player, doorController.teleportLocation, temp, 1);
        }
    }
}
