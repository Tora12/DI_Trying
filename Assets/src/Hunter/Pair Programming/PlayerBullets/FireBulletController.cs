using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletController : MonoBehaviour
{
    private PlayerBullet fireBullet;

    public float fireBulletDamageStat;
    public float fireBulletEffectStat;
    public float fireBulletSpeedStat;
    public int fireBulletEffectDuration;
    public int fireBulletLifetime;

    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, fireBulletLifetime);
        fireBullet = new FireBullet(GetComponent<Rigidbody>(), fireBulletDamageStat, fireBulletEffectStat, fireBulletSpeedStat, fireBulletEffectDuration);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            fireBullet.playerBulletEffect(collider.gameObject);
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}

public class FireBullet : PlayerBullet
{
    public FireBullet(Rigidbody bulletRigidbody, float damageStat, float effectStat, float speedStat, int effectDuration)
    {
        this.damageStat = damageStat;
        this.effectStat = effectStat;
        this.speedStat = speedStat;
        this.effectDuration = effectDuration;
        bulletRigidbody.velocity = Drone.Instance.bulletDirection * speedStat;
    }

    public override void playerBulletEffect(GameObject enemy)
    {

    }
}