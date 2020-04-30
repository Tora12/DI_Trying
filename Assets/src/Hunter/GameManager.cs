using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool inGame;
    private GameObject doll;
    private GameObject player;
    private RaycastHit raycastHit;
    private Rigidbody playerRigidbody;

    public float checkpointDistance;
    public float sweepTestDistance;
    public int closeDoorDelay;
    public int enterRegionDelay;
    public int finishGameDelay;
    public int respawnPlayerDelay;
    public int[] data;
    public Vector3 playerStartLocation;
    public Vector3 playerRespawnLocation;
    public Vector3 playerFinishLocation;
    public Vector3[] checkpointLocation;


    protected GameManager() {}
    public void Start()
    {
        if ((player = GameObject.Find("MainCharacter")) != null)
        {
            inGame = true;
            doll = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Will/PlayerRagdoll.prefab", typeof(GameObject));
            playerRigidbody = player.GetComponent<Rigidbody>();
            playerRespawnLocation = playerStartLocation;
            startGame(player, playerStartLocation, 0);
        }
        else
            inGame = false;
    }
    private void FixedUpdate()
    {
        if (inGame)
        {
            checkPlayerState();
            checkPlayerCollision();
            checkPlayerLocation();
        }
    }


    private IEnumerator despawnEntity_Coroutine(GameObject entity, int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(entity);
    }
    private IEnumerator enterRegion_Coroutine(GameObject player, Vector3 position, int[] data, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = position;
    }
    private IEnumerator finishGame_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu_Scene");
    }
    private IEnumerator respawnPlayer_Coroutine(GameObject player, GameObject doll, Vector3 position, int delay)
    {
        player.SetActive(false);
        player.GetComponent<PlayerController>().Reset();
        GameObject spawnedDoll = spawnEntity(doll, player.transform.position, player.transform.rotation, 0);
        yield return new WaitForSeconds(delay);
        player.transform.position = position;
        despawnEntity(spawnedDoll, 0);
        player.SetActive(true);
    }
    private IEnumerator spawnEntity_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
    }
    private IEnumerator startGame_Coroutine(GameObject player, Vector3 position, int delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = position;
    }
    private void checkPlayerCollision()
    {
        if (playerRigidbody.SweepTest(playerRigidbody.transform.TransformDirection(Vector3.forward), out raycastHit, sweepTestDistance))
        {
            if (raycastHit.transform.gameObject.CompareTag("Area_Door"))
            {
                DoorController doorController = raycastHit.transform.gameObject.GetComponentInParent<DoorController>();
                doorController.openDoor(0);
                doorController.closeDoor(closeDoorDelay);
            }

            if (raycastHit.transform.gameObject.CompareTag("Region_Door"))
            {
                DoorController doorController = raycastHit.transform.gameObject.GetComponentInParent<DoorController>();
                doorController.openDoor(0);
                enterRegion(player, doorController.teleportLocation, data, enterRegionDelay);
            }
        }
    }
    private bool checkGameState()
    {
        if (SceneManager.GetActiveScene().name != "Menu_Scene")
            inGame = false;
        else
            inGame = true;

        return inGame;
    }
    private void checkPlayerState()
    {
        if (player.GetComponent<PlayerController>().isDead)
            respawnPlayer(player, doll, playerRespawnLocation, respawnPlayerDelay);
    }
    private void checkPlayerLocation()
    {
        if (Vector3.Distance(player.transform.position, playerStartLocation) <= checkpointDistance)
            playerRespawnLocation = playerStartLocation;

        foreach (Vector3 vector3 in checkpointLocation)
            if (Vector3.Distance(player.transform.position, vector3) <= checkpointDistance)
                playerRespawnLocation = vector3;

        if (Vector3.Distance(player.transform.position, playerFinishLocation) <= checkpointDistance)
            finishGame(finishGameDelay);
    }


    public void despawnEntity(GameObject entity, int delay)
    {
        StartCoroutine(despawnEntity_Coroutine(entity, delay));
    }
    public void enterRegion(GameObject player, Vector3 position, int[] data, int delay)
    {
        StartCoroutine(enterRegion_Coroutine(player, position, data, delay));
    }
    public void finishGame(int delay)
    {
        StartCoroutine(finishGame_Coroutine(delay));
    }
    public void respawnPlayer(GameObject player, GameObject doll, Vector3 position, int delay)
    {
        StartCoroutine(respawnPlayer_Coroutine(player, doll, position, delay));
    }
    public GameObject spawnEntity(GameObject entity, Vector3 position, Quaternion rotation, int delay)
    {
        StartCoroutine(spawnEntity_Coroutine(delay));
        GameObject spawnedEntity = Instantiate(entity, position, rotation);
        return spawnedEntity;
    }
    public void startGame(GameObject player, Vector3 location, int delay)
    {
        StartCoroutine(startGame_Coroutine(player, location, delay));
    }
}