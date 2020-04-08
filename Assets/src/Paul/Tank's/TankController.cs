using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public float maxHealth = 10;
    public float Health;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Slider slider;
    public TankMovement movement;
    public int EnemyDespawnTime = 2;
    private bool Dead = false;

    private int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

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

            if (num < .5)
                movement.Dead1();
            else
                movement.Dead2();

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
