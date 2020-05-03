using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBullet
{
    public float damageStat;
    public float effectStat;
    public float speedStat;
    public int effectDuration;
    public int fireDelay;
    public int maxAmmo;

    public abstract void playerBulletEffect(GameObject enemy);
}

public abstract class PlayerBulletDamageStatDecorator : PlayerBullet
{
    public abstract void changeDamageStat();
    public override void playerBulletEffect(GameObject enemy) { }
}

public abstract class PlayerBulletEffectStatDecorator : PlayerBullet
{
    public abstract void changeEffectStat();
    public override void playerBulletEffect(GameObject enemy) { }
}

public abstract class PlayerBulletSpeedStatDecorator : PlayerBullet
{
    public abstract void changeSpeedStat();
    public override void playerBulletEffect(GameObject enemy) { }
}

public abstract class PlayerBulletEffectDurationDecorator : PlayerBullet
{
    public abstract void changeEffectDuration();
    public override void playerBulletEffect(GameObject enemy) { }
}

public class PlayerBulletIncreaseDamageStat : PlayerBulletDamageStatDecorator
{
    private PlayerBullet playerBullet;
    private float statIncrease;

    public PlayerBulletIncreaseDamageStat(PlayerBullet playerBullet, float statIncrease)
    {
        this.playerBullet = playerBullet;
        this.statIncrease = statIncrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeDamageStat();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeDamageStat()
    {
        playerBullet.damageStat += statIncrease;
    }
}

public class PlayerBulletDecreaseDamageStat : PlayerBulletDamageStatDecorator
{
    private PlayerBullet playerBullet;
    private float statDecrease;

    public PlayerBulletDecreaseDamageStat(PlayerBullet playerBullet, float statDecrease)
    {
        this.playerBullet = playerBullet;
        this.statDecrease = statDecrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeDamageStat();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeDamageStat()
    {
        playerBullet.damageStat -= statDecrease;
    }
}

public class PlayerBulletIncreaseEffectStat : PlayerBulletEffectStatDecorator
{
    private PlayerBullet playerBullet;
    private float statIncrease;

    public PlayerBulletIncreaseEffectStat(PlayerBullet playerBullet, float statIncrease)
    {
        this.playerBullet = playerBullet;
        this.statIncrease = statIncrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeEffectStat();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeEffectStat()
    {
        playerBullet.effectStat += statIncrease;
    }
}

public class PlayerBulletDecreaseEffectStat : PlayerBulletEffectStatDecorator
{
    private PlayerBullet playerBullet;
    private float statDecrease;

    public PlayerBulletDecreaseEffectStat(PlayerBullet playerBullet, float statDecrease)
    {
        this.playerBullet = playerBullet;
        this.statDecrease = statDecrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeEffectStat();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeEffectStat()
    {
        playerBullet.effectStat -= statDecrease;
    }
}

public class PlayerBulletIncreaseEffectDuration : PlayerBulletEffectDurationDecorator
{
    private PlayerBullet playerBullet;
    private int durationIncrease;

    public PlayerBulletIncreaseEffectDuration(PlayerBullet playerBullet, int durationIncrease)
    {
        this.playerBullet = playerBullet;
        this.durationIncrease = durationIncrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeEffectDuration();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeEffectDuration()
    {
        playerBullet.effectDuration += durationIncrease;
    }
}

public class PlayerBulletDecreaseEffectDuration : PlayerBulletEffectDurationDecorator
{
    private PlayerBullet playerBullet;
    private int durationDecrease;

    public PlayerBulletDecreaseEffectDuration(PlayerBullet playerBullet, int durationDecrease)
    {
        this.playerBullet = playerBullet;
        this.durationDecrease = durationDecrease;
    }

    public override void playerBulletEffect(GameObject enemy)
    {
        changeEffectDuration();
        playerBullet.playerBulletEffect(enemy);
    }

    public override void changeEffectDuration()
    {
        playerBullet.effectDuration -= durationDecrease;
    }
}