using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : MonoBehaviour
{
    private BulletElement iceBuff;
    private Rigidbody rigidBody; // Rigidbody for Bullet.prefab

    public float iceBuffEffect = 0f; // Slow effect
    public float iceBuffDuration = 0f; // Slow duration

    public int damage = 20;
    public float speed = 20f;
    public int levelUp = 10;
    private int hitCombo = 0;


    // Start is called before the first frame update
    void Start()
    {
        iceBuff = new IceBuff(iceBuffEffect, iceBuffDuration);
        //iceBuff = new IncreaseDuration();
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.velocity = Dron.Instance.droneTarget * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1); // Despawns Bullet.prefab after 1 second

        // Consecutive attacks rewards player with extra damage
        if (hitCombo >= levelUp)
        {
            damage += 5;
            levelUp *= 2;
            hitCombo = 0;
        }
    }

    // Method that damages enemies when bullet collides with enemy
    private void OnTriggerEnter(Collider hitInfo)
    {

        AutoCannonController enemy = hitInfo.GetComponent<AutoCannonController>();

        //Debug.Log(hitInfo.name);

        if (enemy != null)
        {
            //enemy.takeDamage(damage);
            hitCombo++;
        }
        else
        {
            hitCombo = 0;
        }

        Destroy(gameObject);
    }
}

public class IceBulle : BulletElement
{
    public IceBulle(float iceBuffEffect, float iceBuffDuration)
    {
        this.elementBuffEffect = iceBuffEffect;
        this.elementBuffDuration = iceBuffDuration;
    }

    public override void increaseElementBuff()
    {
        applyBuff();
    }

    private void applyBuff()
    {
        // Logic to apply debuff to enemy
    }
}