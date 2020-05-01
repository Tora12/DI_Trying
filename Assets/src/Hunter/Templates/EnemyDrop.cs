using UnityEngine;

public abstract class EnemyDrop
{
    protected GameObject player;
    public int effectDuration;
    public float effectStat;

    public virtual void enemyDropEffect() { }
}

public abstract class EffectDurationDecorator : EnemyDrop
{
    public virtual void changeEffectDuration() { }
    public override void enemyDropEffect() { }
}

public class IncreaseDuration : EffectDurationDecorator
{
    private EnemyDrop enemyDrop;
    private int durationIncrease;

    public IncreaseDuration(EnemyDrop enemyDrop, int durationIncrease)
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

public class DecreaseDuration : EffectDurationDecorator
{
    private EnemyDrop enemyDrop;
    private int durationDecrease;

    public DecreaseDuration(EnemyDrop enemyDrop, int durationDecrease)
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

public abstract class EffectStatDecorator : EnemyDrop
{
    public virtual void changeEffectStat() { }
    public override void enemyDropEffect() { }
}

public class IncreaseStat : EffectStatDecorator
{
    private EnemyDrop enemyDrop;
    private float statIncrease;

    public IncreaseStat(EnemyDrop enemyDrop, float statIncrease)
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

public class DecreaseStat : EffectStatDecorator
{
    private EnemyDrop enemyDrop;
    private float statDecrease;

    public DecreaseStat(EnemyDrop enemyDrop, float statDecrease)
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