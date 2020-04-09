using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    public float maxHealth = 10;
    public float Health;
    public int fireDelay = 0;
    [SerializeField] private TowerMovement movement;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Slider slider;
    private int EnemyDespawnTime = 0;
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
        if (Health < maxHealth)
        {
            HealthBar.SetActive(true);
        }

        //Handles Enemy Death Animation Triggering.
        if (Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
            //Removes the Health Bar
            Destroy(HealthBar);
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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            movement.Fire();
        }
    }
}
