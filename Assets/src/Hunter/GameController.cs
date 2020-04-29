using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 startLocation = Vector3.zero;
    public Vector3 endLocation = Vector3.zero;
    public Vector3[] checkpointLocations = new Vector3[1];

    [HideInInspector] public Vector3 respawnLocation;
    [HideInInspector] public int[] AI_Data;

    private GameObject player;
    private RaycastHit raycastHit;
    private new Rigidbody rigidbody;
    private GameTriggers gameTriggers;
    private float collisionCheckDistance;
    private float checkpointReachedDistance;

    [SerializeField] private GameObject ragDoll = null;

    void Start()
    {
        checkpointLocations[0] = startLocation;
        respawnLocation = startLocation;
        player = GameObject.FindWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody>();
        gameTriggers = GameObject.Find("EventSystem").GetComponent<GameTriggers>();
        collisionCheckDistance = 1.0f;
        checkpointReachedDistance = 0.2f;
        gameTriggers.startGame(player, startLocation, 0);
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
        
        foreach (Vector3 i in checkpointLocations)
            if (Vector3.Distance(player.transform.position, i) <= checkpointReachedDistance)
                respawnLocation = i;

        if (Vector3.Distance(player.transform.position, endLocation) <= checkpointReachedDistance)
            gameTriggers.finishGame(3);
    }
}