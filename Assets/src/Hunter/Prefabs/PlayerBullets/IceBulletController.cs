using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : MonoBehaviour
{
    private PlayerBullet iceBullet;
    
    public float iceBulletDamageStat;
    public float iceBulletEffectStat;
    public float iceBulletSpeedStat;
    public int iceBulletEffectDuration;
    public int iceBulletFireDelay;
    public int iceBulletLifetime;
    public int iceBulletMaxAmmo;

    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, iceBulletLifetime);
        iceBullet = new IceBullet(GetComponent<Rigidbody>(), iceBulletDamageStat, iceBulletEffectStat, iceBulletSpeedStat, iceBulletEffectDuration, iceBulletFireDelay, iceBulletMaxAmmo);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            iceBullet.playerBulletEffect(collider.gameObject);
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}

public class IceBullet : PlayerBullet
{
    public IceBullet(Rigidbody bulletRigidbody, float damageStat, float effectStat, float speedStat, int effectDuration, int fireDelay, int maxAmmo)
    {
        this.damageStat = damageStat;
        this.effectStat = effectStat;
        this.speedStat = speedStat;
        this.effectDuration = effectDuration;
        this.fireDelay = fireDelay;
        this.maxAmmo = maxAmmo;
        bulletRigidbody.velocity = Drone.Instance.bulletDirection * speedStat;
    }

    public override void playerBulletEffect(GameObject enemy)
    {

    }
}