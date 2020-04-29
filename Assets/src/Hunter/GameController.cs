using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 endpoint;
    public Vector3[] checkpoints;
    public float collisionCheckDistance;
    [HideInInspector] public int[] AI_Data;

    private GameObject player;
    private RaycastHit raycastHit;
    private new Rigidbody rigidbody;
    private Vector3 respawnLocation;
    private GameTriggers gameTriggers;

    [SerializeField] private GameObject ragDoll = null;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody>();
        gameTriggers = GameObject.Find("EventSystem").GetComponent<GameTriggers>();
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

        if(checkpoints != null && checkpoints.Length != 0)
            foreach (Vector3 i in checkpoints)
                if (Vector3.Distance(player.transform.position, i) <= 0.2)
                    respawnLocation = i;

        if (Vector3.Distance(player.transform.position, endpoint) <= 0.2)
            gameTriggers.finishGame(3);
    }
}