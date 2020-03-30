using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherController : MonoBehaviour
{
    public int Health = 100;
    public RocketLauncherMovement movement;
    public int EnemyDespawnTime = 2;
    private bool Dead = false;

    private int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

    void Update()
    {
        //Handles Enemy Death Animation Triggering.
        if (Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
            //Generates a random number to play one of four death animations.
            float num = Random.value;

            if (num <= .25)
                movement.Dead1();
            else if (num <= .5)
                movement.Dead2();
            else if (num <= .75)
                movement.Dead3();
            else
                movement.Dead4();

            Destroy(gameObject, EnemyDespawnTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Health = Health - Damage;
        }
    }
}
