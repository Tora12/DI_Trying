using UnityEngine;

public abstract class BulletElement {

  public float elementBuffEffect;
  public float elementBuffDuration;

  public virtual void increaseElementBuff() {} // Dynamic binding

}

public class ElementDecorator : BulletElement
{
  public override void increaseElementBuff() {}
}

public class IncreaseElementEffect : ElementDecorator {

  private BulletElement bulletElement;
  private float buffEffectIncrease;

  // Constructor
  public IncreaseElementEffect(BulletElement bulletElement, float buffEffectIncrease) {
    this.bulletElement = bulletElement;
    this.buffEffectIncrease = buffEffectIncrease;
  }

  public override void increaseElementBuff() {
    bulletElement.elementBuffEffect += buffEffectIncrease;
  }

}

public class IncreaseElementDuration : ElementDecorator {

  private BulletElement bulletElement;
  private float buffDurationIncrease;

  // Constructor
  public IncreaseElementDuration(BulletElement bulletElement, float buffDurationIncrease) {
    this.bulletElement = bulletElement;
    this.buffDurationIncrease = buffDurationIncrease;
  }

  public override void increaseElementBuff() {
    bulletElement.elementBuffDuration += buffDurationIncrease;
  }

}
