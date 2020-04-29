using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float collisionCheckDistance;
    public int[] AI_Data;
    public Vector3[] checkpoints;
    
    private Rigidbody rigidbody;
    private RaycastHit raycastHit;
    private Vector3 respawnLocation;

    [SerializeField] private GameObject ragDoll;
    [SerializeField] private GameTriggers gameTriggers;

    void Start()
    {
        rigidbody = player.GetComponent<Rigidbody>();
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

        foreach (Vector3 i in checkpoints)
            if (Vector3.Distance(player.transform.position, i) <= 0.2)
                respawnLocation = i;
    }
}