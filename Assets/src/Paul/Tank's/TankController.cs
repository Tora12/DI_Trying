using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public float maxHealth = 10;
    public float Health;
    public float minFireDelay = 0.1f;
    public float maxFireDelay = 1.0f;
    private float fireDelay;
    public GameObject HealthBar;
    public GameObject canvas;
    public Slider slider;
    public TankMovement movement;
    public int EnemyDespawnTime = 2;
    private bool Dead = false;
    public GameObject eye = null;
    private float lastAttackTime;

    private readonly int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

    void Start()
    {
        Health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = Health;
        RandomFireDelay();
    }

    void Update()
    {
        if (Health < maxHealth)
        {
            canvas.SetActive(true);
            HealthBar.SetActive(true);
        }

        //Handles Enemy Death Animation Triggering.
        if (Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
            //Removes the Health Bar
            //Destroy(HealthBar);
            //Generates a random number to play one of four death animations.
            float num = Random.value;

            if (num < .5)
                movement.Dead1();
            else
                movement.Dead2();

            Destroy(gameObject, EnemyDespawnTime);
        }

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.

        if (eye != null)
        {
            if (Physics.Raycast(eye.transform.position, transform.TransformDirection(Vector3.forward), out _, 20, layerMask) && !Dead && (Time.time > lastAttackTime + fireDelay))
            {
                movement.Fire();
                lastAttackTime = Time.time;
                RandomFireDelay();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Health -= Damage;
            slider.value = Health;
        }
    }

    //Depercated
    /*
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canFire = false;
        }
    }

    void fire()
    {
        StartCoroutine(fire_Coroutine());
    }

    IEnumerator fire_Coroutine()
    {
        while (canFire)
        {
            movement.Fire();
            randomFireDelay();
            yield return new WaitForSeconds(fireDelay);
        }
    }
    */

    private void RandomFireDelay()
    {
        fireDelay = Random.Range(minFireDelay, maxFireDelay);
    }
}
