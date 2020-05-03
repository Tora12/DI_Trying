using UnityEngine;

public abstract class EnemyDrop
{
    protected GameObject player;

    public float effectStat;
    public int effectDuration;

    public virtual void enemyDropEffect() { }
}

public abstract class EnemyDropEffectDurationDecorator : EnemyDrop
{
    public virtual void changeEffectDuration() { }
    public override void enemyDropEffect() { }
}

public abstract class EnemyDropEffectStatDecorator : EnemyDrop
{
    public virtual void changeEffectStat() { }
    public override void enemyDropEffect() { }
}

public class EnemyDropIncreaseDuration : EnemyDropEffectDurationDecorator
{
    private EnemyDrop enemyDrop;
    private int durationIncrease;

    public EnemyDropIncreaseDuration(EnemyDrop enemyDrop, int durationIncrease)
    {
        this.enemyDrop = enemyDrop;
        this.durationIncrease = durationIncrease;
    }

    public override void enemyDropEffect()
    {
        changeEffectDuration();
        enemyDrop.enemyDropEffect();
    }

    public override void changeEffectDuration()
    {
        enemyDrop.effectDuration += durationIncrease;
    }
}

public class EnemyDropDecreaseDuration : EnemyDropEffectDurationDecorator
{
    private EnemyDrop enemyDrop;
    private int durationDecrease;

    public EnemyDropDecreaseDuration(EnemyDrop enemyDrop, int durationDecrease)
    {
        this.enemyDrop = enemyDrop;
        this.durationDecrease = durationDecrease;
    }

    public override void enemyDropEffect()
    {
        changeEffectDuration();
        enemyDrop.enemyDropEffect();
    }

    public override void changeEffectDuration()
    {
        enemyDrop.effectDuration += durationDecrease;
    }
}

public class EnemyDropIncreaseStat : EnemyDropEffectStatDecorator
{
    private EnemyDrop enemyDrop;
    private float statIncrease;

    public EnemyDropIncreaseStat(EnemyDrop enemyDrop, float statIncrease)
    {
        this.enemyDrop = enemyDrop;
        this.statIncrease = statIncrease;
    }

    public override void enemyDropEffect()
    {
        changeEffectStat();
        enemyDrop.enemyDropEffect();
    }

    public override void changeEffectStat()
    {
        enemyDrop.effectStat += statIncrease;
    }
}

public class EnemyDropDecreaseStat : EnemyDropEffectStatDecorator
{
    private EnemyDrop enemyDrop;
    private float statDecrease;

    public EnemyDropDecreaseStat(EnemyDrop enemyDrop, float statDecrease)
    {
        this.enemyDrop = enemyDrop;
        this.statDecrease = statDecrease;
    }

    public override void enemyDropEffect()
    {
        changeEffectStat();
        enemyDrop.enemyDropEffect();
    }

    public override void changeEffectStat()
    {
        enemyDrop.effectStat += statDecrease;
    }
}