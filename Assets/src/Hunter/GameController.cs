using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float collisionCheckDistance;
    public int[] AI_Data;


    private Rigidbody rigidbody;
    public Vector3 respawnLocation;

    [SerializeField] private GameTriggers gameTriggers;

    void Start()
    {
        //       Vector3 test = new Vector3(-0.058f, 0.51f, -90f);
        //       gameTriggers.enterRoom(player, test, temp, 5);

        rigidbody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit raycastHit;

        if(player.GetComponent<PlayerHealthandDamage>().dead)
            gameTriggers.respawnPlayer(player, respawnLocation, 0);

        if (rigidbody.SweepTest(rigidbody.transform.TransformDirection(Vector3.forward), out raycastHit, collisionCheckDistance))
        {
            if (raycastHit.transform.tag == "Region_Door")
            {
                DoorController doorController = raycastHit.transform.gameObject.GetComponentInParent<DoorController>();
                doorController.openDoor(0);
                gameTriggers.enterRegion(player, doorController.teleportLocation, AI_Data, 1);
            }

            if (raycastHit.transform.tag == "Area_Door")
            {
                DoorController doorController = raycastHit.transform.gameObject.GetComponentInParent<DoorController>();
                doorController.openDoor(0);
                doorController.closeDoor(3);
            }
        }
    }
}