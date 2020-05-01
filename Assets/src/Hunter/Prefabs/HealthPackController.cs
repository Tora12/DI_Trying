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
        //healthPack = new IncreaseStat(healthPack, 10.0f);
        //healthPack = new DecreaseStat(healthPack, 5.0f);
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