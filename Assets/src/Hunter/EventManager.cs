using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Tooltip("The maximum distance the player can be from a checkpoint and still count it as reached.")]
    public float checkpointDistance;
    [Tooltip("The maximum distance of the rigidbody sweep test.")]
    public float sweepTestDistance;
    [Tooltip("The delay for any call to close a door.")]
    public int closeDoorDelay;
    [Tooltip("The delay for any call to enter a region.")]
    public int enterRegionDelay;
    [Tooltip("The delay for any call to finish the game.")]
    public int finishGameDelay;
    [Tooltip("The delay for any call to respawn the player.")]
    public int respawnPlayerDelay;
    [Tooltip("The location the player will spawn at the start of the game.")]
    public Vector3 playerStartLocation;
    [Tooltip("The location the player must reach to complete the level and finish the game.")]
    public Vector3 playerFinishLocation;
    [Tooltip("An array of locations where the player will respawn at upon death if reached.")]
    public Vector3[] checkpointLocations;

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
        GameManager.Instance.checkpointLocations = checkpointLocations;
        GameManager.Instance.Start();
    }
}
