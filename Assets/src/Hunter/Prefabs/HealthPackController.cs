/* HealthPackController.cs should be placed on an asset to create the prefab.
 * Edit the enemyDropEffect() function of the HealthPack class to change how to item works.
 * Use the decorators found in EnemyDrop.cs to implement variability in the health packs you spawn.
 * Other than that, the GameManager will handle spawning the prefab.
 */
using UnityEngine;

public class HealthPackController : MonoBehaviour
{
    private EnemyDrop healthPack;
    private GameObject player;
    
    public int healthPackLifetime;
    public float healthPackStat;



    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, healthPackLifetime);
        player = GameObject.Find("MainCharacter");
        healthPack = new HealthPack(player, healthPackStat);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthPack.enemyDropEffect();
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}
public class HealthPack : EnemyDrop
{
    public HealthPack(GameObject player, float effectStat)
    {
        this.player = player;
        this.effectStat = effectStat;
    }

    public override void enemyDropEffect()
    {
        if (player.GetComponent<PlayerHealthandDamage>().health <= player.GetComponent<PlayerHealthandDamage>().max_health - effectStat)
            player.GetComponent<PlayerHealthandDamage>().health += effectStat;
        else
            player.GetComponent<PlayerHealthandDamage>().health = player.GetComponent<PlayerHealthandDamage>().max_health;
    }
}