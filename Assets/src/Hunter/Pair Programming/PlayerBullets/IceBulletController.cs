﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : MonoBehaviour
{
    private PlayerBullet iceBullet;

    public float iceBulletDamageStat;
    public float iceBulletEffectStat;
    public float iceBulletSpeedStat;
    public int iceBulletEffectDuration;
    public int iceBulletLifetime;


    private void Start()
    {
        GameManager.Instance.despawnEntity(gameObject, iceBulletLifetime);
        iceBullet = new IceBullet(GetComponent<Rigidbody>(), iceBulletDamageStat, iceBulletEffectStat, iceBulletSpeedStat, iceBulletEffectDuration);
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
    public IceBullet(Rigidbody bulletRigidbody, float damageStat, float effectStat, float speedStat, int effectDuration)
    {
        this.damageStat = damageStat;
        this.effectStat = effectStat;
        this.speedStat = speedStat;
        this.effectDuration = effectDuration;
        bulletRigidbody.velocity = Drone.Instance.bulletDirection * speedStat;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        if (enemy.GetComponentInParent<AutoCannonController>() != null)
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
