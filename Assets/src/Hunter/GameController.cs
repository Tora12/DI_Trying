using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float collisionCheckDistance;
    public int[] AI_Data;
    
    private Rigidbody rigidbody;
    private RaycastHit raycastHit;
    private Vector3 respawnLocation;

    [SerializeField] private GameObject ragDoll;
    [SerializeField] private GameTriggers gameTriggers;

    void Start()
    {
        rigidbody = player.GetComponent<Rigidbody>();
        respawnLocation = new Vector3(-1.7094e-06f, 17.1f, 268.4f);
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().isDead)
            gameTriggers.respawnPlayer(player, ragDoll, respawnLocation, 3);

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