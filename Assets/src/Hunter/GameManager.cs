using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //A boolean that indicates if the user is in the game
    private bool inGame;
    //The rag doll that will spawn at the player's location upon death
    private GameObject doll;
    //The player that the user will control
    private GameObject player;
    //The object that collides with the player in a sweep test
    private RaycastHit raycastHit;
    //The rigidbody of the player that senses collision
    private Rigidbody playerRigidbody;

    //The maximum distance the player can be from a checkpoint and still count it as reached
    [HideInInspector] public float checkpointDistance;
    //The maximum distance of the rigidbody sweep test
    [HideInInspector] public float sweepTestDistance;
    //The delay for any call to close a door
    [HideInInspector] public int closeDoorDelay;
    //The rate that enemy drops will spawn upon killing an enemy
    [HideInInspector] [Range(0, 100)] public int enemyDropRate;
    //The delay for any call to enter a region
    [HideInInspector] public int enterRegionDelay;
    //The delay for any call to finish the game
    [HideInInspector] public int finishGameDelay;
    //The delay for any call to respawn the player
    [HideInInspector] public int respawnPlayerDelay;
    //An array of integers used to adapt the enemies' A.I. between regions
    [HideInInspector] public int[] data;
    //The location the player will spawn at the start of the game
    [HideInInspector] public Vector3 playerStartLocation;
    //The location the player will respawn at upon death
    [HideInInspector] public Vector3 playerRespawnLocation;
    //The location the player must reach to complete the level and finish the game
    [HideInInspector] public Vector3 playerFinishLocation;
    //An array of locations that will update the player's respawn location if reached
    [HideInInspector] public Vector3[] checkpointLocations;



    protected GameManager() {}
    private void FixedUpdate()
    {
        if (inGame) // checks if the user is in the game
        {
            checkPlayerState();
            checkPlayerCollision();
            checkPlayerLocation();
        }
    }
    public void Start()
    {
        if ((player = GameObject.Find("MainCharacter")) != null) // tries to find an object in the hierarchy called MainCharacter, then checks if one was found
        {
            inGame = true; // means that the user is in the game
            doll = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Will/PlayerRagdoll.prefab", typeof(GameObject)); // finds the PlayerRagdoll prefab in the directory
            playerRigidbody = player.GetComponent<Rigidbody>();
            playerRespawnLocation = playerStartLocation;
            startGame(player, playerStartLocation, 0);
        }
        else // if a MainCharacter object wasn't found
            inGame = false; // means that the user ins't in the game
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

    /// <summary>
    /// Exits the game and returns to the main menu.
    /// </summary>
    /// <param name="delay">The delay before executing this function.</param>
    private IEnumerator finishGame_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu_Scene");
    }

    /// <summary>
    /// Deactivates the player and spawns a rag doll at the player's position, then after the given delay moves the player to the specified position.
    /// </summary>
    /// <param name="player">The player that the user controls.</param>
    /// <param name="doll">The rag doll to spawn upon death.</param>
    /// <param name="position">The position to move the player to.</param>
    /// <param name="delay">The delay before executing this function.</param>
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

    /// <summary>
    /// Spawns a copy of the given enemy drop at the specified position after the given delay.
    /// </summary>
    /// <param name="enemyDrop">The enemy drop to spawn.</param>
    /// <param name="position">The position to spawn the enemy drop at.</param>
    /// <param name="delay">The delay before executing this function.</param>
    private IEnumerator spawnEnemyDrop_Coroutine(GameObject enemyDrop, Vector3 position, int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    /// <summary>
    /// Spawns a copy of the given entity at the specified position and rotation after the given delay.
    /// </summary>
    /// <param name="delay">The delay before executing this function.</param>
    private IEnumerator spawnEntity_Coroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    /// <summary>
    /// Moves the player to the specified position and initializes the game after the given delay.
    /// </summary>
    /// <param name="player">The player that the user controls.</param>
    /// <param name="position">The position to move the player to.</param>
    /// <param name="delay">The delay before executing this function.</param>
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

            if (raycastHit.transform.gameObject.CompareTag("Enemy_Drop"))
            {
                despawnEntity(raycastHit.transform.gameObject, 0);
            }

            /*
            if (raycastHit.transform.gameObject.CompareTag("AudioStuffz"))
            {
                SoundManager.Instance.playSound();
            }
            */
        }
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

        foreach (Vector3 vector3 in checkpointLocations)
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

    /// <summary>
    /// Exits the game and returns to the main menu.
    /// </summary>
    /// <param name="delay">The delay before executing this function.</param>
    public void finishGame(int delay)
    {
        StartCoroutine(finishGame_Coroutine(delay));
    }

    /// <summary>
    /// Deactivates the player and spawns a rag doll at the player's position, then after the given delay moves the player to the specified position.
    /// </summary>
    /// <param name="player">The player that the user controls.</param>
    /// <param name="doll">The rag doll to spawn upon death.</param>
    /// <param name="position">The position to move the player to.</param>
    /// <param name="delay">The delay before executing this function.</param>
    public void respawnPlayer(GameObject player, GameObject doll, Vector3 position, int delay)
    {
        StartCoroutine(respawnPlayer_Coroutine(player, doll, position, delay));
    }

    /// <summary>
    /// Spawns a copy of a random enemy drop at the specified position after the given delay.
    /// </summary>
    /// <param name="position">The position to spawn the enemy drop at.</param>
    /// <param name="delay">The delay before executing this function.</param>
    /// <returns>The spawned copy of the random enemy drop.</returns>
    public GameObject spawnEnemyDrop(Vector3 position, int delay)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int dropRate = Random.Range(1, 100);
        Debug.Log(dropRate);

        if (dropRate < enemyDropRate)
        {
            GameObject[] prefabs = (PrefabLoader.LoadAllPrefabsAt(@"Assets/Prefabs/Hunter/EnemyDrops")).ToArray();
            GameObject spawnedEnemyDrop = spawnEntity(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity, delay);
            return spawnedEnemyDrop;
        }
        
        return null;
    }

    /// <summary>
    /// Spawns a copy of the given entity at the specified position and rotation after the given delay.
    /// </summary>
    /// <param name="entity">The entity to spawn.</param>
    /// <param name="position">The position to spawn the entity at.</param>
    /// <param name="rotation">The rotation to spawn the entity with.</param>
    /// <param name="delay">The delay before executing this function.</param>
    /// <returns>The spawned copy of the given entity.</returns>
    public GameObject spawnEntity(GameObject entity, Vector3 position, Quaternion rotation, int delay)
    {
        StartCoroutine(spawnEntity_Coroutine(delay));
        GameObject spawnedEntity = Instantiate(entity, position, rotation);
        return spawnedEntity;
    }

    /// <summary>
    /// Moves the player to the specified position and initializes the game after the given delay.
    /// </summary>
    /// <param name="player">The player that the user controls.</param>
    /// <param name="position">The position to move the player to.</param>
    /// <param name="delay">The delay before executing this function.</param>
    public void startGame(GameObject player, Vector3 position, int delay)
    {
        StartCoroutine(startGame_Coroutine(player, position, delay));
    }
}