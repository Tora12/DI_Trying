using System.Collections;
using UnityEngine;

public class SpeedBoostController : MonoBehaviour
{
    private EnemyDrop speedBoost;
    private GameObject player;

    public int speedBoostDuration;
    public int speedBoostLifetime;
    public float speedBoostStat;



    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, speedBoostLifetime);
        player = GameObject.Find("MainCharacter");
        speedBoost = new SpeedBoost(player, speedBoostDuration, speedBoostStat);
        //speedBoost = new IncreaseDuration(speedBoost, 10);
        //speedBoost = new DecreaseDuration(speedBoost, 5);
        //speedBoost = new IncreaseStat(speedBoost, 10.0f);
        //speedBoost = new DecreaseStat(speedBoost, 5.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            speedBoost.enemyDropEffect();
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}

public class SpeedBoost : EnemyDrop
{
    public SpeedBoost(GameObject player, int effectDuration, float effectStat)
    {
        this.player = player;
        this.effectDuration = effectDuration;
        this.effectStat = effectStat;
    }
    public override void enemyDropEffect()
    {
        GameManager.Instance.startCoroutine(enemyDropEffect_Coroutine());
    }
    private IEnumerator enemyDropEffect_Coroutine()
    {
        player.GetComponent<PlayerMovement>().MoveSpeedMultiplier += effectStat;
        yield return new WaitForSeconds(effectDuration);
        player.GetComponent<PlayerMovement>().MoveSpeedMultiplier -= effectStat;
    }
}