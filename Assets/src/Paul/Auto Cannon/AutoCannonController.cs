using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCannonController : MonoBehaviour
{
    public float maxHealth = 10;
    public float Health;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Slider slider;
    public AutoCannonMovement movement;
    public int EnemyDespawnTime = 2;
    private bool Dead = false;

    private int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = Health;
    }

    void Update()
    {
        //Handles Enemy Death Animation Triggering.
        if(Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
            //Removes the Health Bar
            Destroy(HealthBar);
            //Generates a random number to play one of four death animations.
            float num = Random.value;

            //Handles playing one of the four death animations.
            if (num <= .25)
                movement.Dead1();
            else if (num <= .5)
                movement.Dead2();
            else if (num <= .75)
                movement.Dead3();
            else
                movement.Dead4();
            
            //Removes the enemy after the time has elepased.
            Destroy(gameObject, EnemyDespawnTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Health = Health - Damage;
            slider.value = Health;
        }
    }
}
