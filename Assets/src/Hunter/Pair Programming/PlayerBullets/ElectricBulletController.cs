using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBulletController : MonoBehaviour
{
    private PlayerBullet electricBullet;

    public float electricBulletDamageStat;
    public float electricBulletEffectStat;
    public float electricBulletSpeedStat;
    public int electricBulletEffectDuration;
    public int electricBulletLifetime;

    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, electricBulletLifetime);
        electricBullet = new ElectricBullet(GetComponent<Rigidbody>(), electricBulletDamageStat, electricBulletEffectStat, electricBulletSpeedStat, electricBulletEffectDuration);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            electricBullet.playerBulletEffect(collider.gameObject);
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}

public class ElectricBullet : PlayerBullet
{
    public ElectricBullet(Rigidbody bulletRigidbody, float damageStat, float effectStat, float speedStat, int effectDuration)
    {
        this.damageStat = damageStat;
        this.effectStat = effectStat;
        this.speedStat = speedStat;
        this.effectDuration = effectDuration;
        bulletRigidbody.velocity = Drone.Instance.bulletDirection * speedStat;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        if(enemy.GetComponentInParent<AutoCannonController>() != null)
        {
            enemy.GetComponentInParent<AutoCannonController>().Damage(damageStat);
            return;
        }

        if (enemy.GetComponentInParent<TankController>() != null)
        {
            enemy.GetComponentInParent<TankController>().Damage(damageStat);
            return;
        }

        if (enemy.GetComponentInParent<TowerController>() != null)
        {
            enemy.GetComponentInParent<TowerController>().Damage(damageStat);
            return;
        }
    }
}