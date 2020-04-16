using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    public float maxHealth = 10;
    public float Health;
    public float minFireDelay = 0.5f;
    public float maxFireDelay = 1.0f;
    private float fireDelay;
    public TowerMovement movement;
    public GameObject HealthBar;
    public GameObject canvas;
    public Slider slider;
    private int EnemyDespawnTime = 0;
    private bool Dead = false;
    public GameObject eye = null;
    private float lastAttackTime;

    private readonly int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = Health;
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
            Destroy(gameObject, EnemyDespawnTime);
        }

        // Bit shift the index of the layer (8) to get a bit mask
        // This would cast rays only against colliders in layer 8.
        int layerMask = 1 << 8;

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
            Health = Health - Damage;
            slider.value = Health;
        }
    }

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
