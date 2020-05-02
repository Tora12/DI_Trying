/* JumpBoostController.cs should be placed on an asset to create the prefab.
 * Edit the enemyDropEffect() function of the JumpBoost class to change how to item works.
 * Use the decorators found in EnemyDrop.cs to implement variability in the jump boosts you spawn.
 * Other than that, the GameManager will handle spawning the prefab.
 */
using System.Collections;
using UnityEngine;

public class JumpBoostController : MonoBehaviour
{
    private EnemyDrop jumpBoost;
    private GameObject player;

    public int jumpBoostDuration;
    public int jumpBoostLifetime;
    public float jumpBoostStat;



    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, jumpBoostLifetime);
        player = GameObject.Find("MainCharacter");
        jumpBoost = new JumpBoost(player, jumpBoostDuration, jumpBoostStat);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jumpBoost.enemyDropEffect();
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}

public class JumpBoost : EnemyDrop
{
    public JumpBoost(GameObject player, int effectDuration, float effectStat)
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
        player.GetComponent<PlayerMovement>().JumpPower += effectStat;
        yield return new WaitForSeconds(effectDuration);
        player.GetComponent<PlayerMovement>().JumpPower -= effectStat;
    }
}
