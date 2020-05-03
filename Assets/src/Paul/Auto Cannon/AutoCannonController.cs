﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(AutoCannonMovement))]
public class AutoCannonController : MonoBehaviour
{
    [Header("Scripts")]
    //Public
    [Tooltip("This is the script that contains the definitions for movement, and shooting.")]
    public AutoCannonMovement movement = null;

    [Header("Health")]
    //Public
    [Tooltip("The maximum ammount of health that the enemy can have.")]
    public float maxHealth = 10;
    [Tooltip("The health bar slider GameObject.\nThis is for enabling and disabling the health bar.")]
    public GameObject healthBar;
    [Tooltip("The canvas that the health bar is attached to.")]
    public GameObject canvas;
    [Tooltip("The slider that is the enemy health bar.\nThis is for updating the slider values.")]
    public Slider slider;
    [Tooltip("How long after the enemy dies, it is removed.")]
    public readonly int enemyDespawnTime = 2;
    [HideInInspector] public float health;
    //Private
    private bool isDead = false;
    
    [Header("Shooting")]
    //Public
    [Tooltip("Where you would like the raycast to cast from.")]
    public GameObject eye = null;
    [Tooltip("The shortest time between the enemy firing.")]
    public float minFireDelay = 0.1f;
    [Tooltip("The longest time between the enemy firing.")]
    public float maxFireDelay = 1.0f;
    [Tooltip("The \"agro\" range of the enemy.\nIt controls how far the raycast is shot out.")]
    public int maxDistance = 20;
    //Private
    private float fireDelay;
    private float lastAttackTime;
    private int layerMask = 1 << 8;

    [Header("AI")]
    //Public
    [Tooltip("An array where you place blank points in the world.\nThese are places that you want the enemy to move to.")]
    public GameObject[] navPoints = null;
    [Tooltip("The shortest time that the enemy will stay at a location.")]
    public float minNavDelay = 3.0f;
    [Tooltip("The longest time that the enemy will stay at a location.")]
    public float maxNavDelay = 8.0f;
    //Private
    private NavMeshAgent agent;
    private bool canNav = false;
    private float lastNavTime;
    private float navDelay;

    private readonly int Damage = 10; //REMOVE WHEN JENNER GETS A DAMAGE VALUE FOR BULLETS

    // Start is called before the first frame update
    void Start()
    {
        //Set the value of Health to the Maximum
        health = maxHealth;

        //Checks if the slider has been assigned to.
        if (slider != null)
        {
            //Set the Heath Bar Maximum value to the Maximum Health
            slider.maxValue = maxHealth;
            //Set the current Health Bar value to the current value of Health
            slider.value = health;
        }
        else
            Debug.LogError("Health Bar not found.");
        
        //Checks if this Enemy is using a NavMesh.
        if (navPoints != null && navPoints.Length > 0)
        {
            canNav = true;
            agent = GetComponent<NavMeshAgent>();
            RandomNavDelay();
        }
        
        RandomFireDelay();
    }
    
    void Update()
    {
        //Activates the Health Bar
        if (health < maxHealth)
        {
            canvas.SetActive(true);
            healthBar.SetActive(true);
        }

        //Handles Enemy Death Animation Triggering.
        if(health <= 0 && !isDead)
        {
            //Prevents the Animation from constantly replaying.
            isDead = true;
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
            Destroy(gameObject, enemyDespawnTime);

            //Spawns Enemy Drops
            GameManager.Instance.spawnEnemyDrop(eye.transform.position, enemyDespawnTime);
        }
        
        //Handles the shooting
        if (eye != null)
        {
            if (Physics.Raycast(eye.transform.position, transform.TransformDirection(Vector3.forward), out _, + maxDistance, layerMask) && !isDead && (Time.time > lastAttackTime + fireDelay))
            {
                movement.Fire();
                lastAttackTime = Time.time;
                RandomFireDelay();
            }
        }
        else
            Debug.LogError("Eye not found.");

        //Handles the Nav Mesh Agent
        if (canNav)
        {
            if((Time.time > lastNavTime + navDelay) && !isDead)
            {
                agent.SetDestination(NavPoint());
                lastNavTime = Time.time;
                RandomNavDelay();
            }
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
        healthBar.SetActive(false);
        canvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            health -= Damage;
            slider.value = health;
        }
    }
 
    //Assigns a random value within the range to publicly accessable varrible
    private void RandomFireDelay()
    {
        fireDelay = Random.Range(minFireDelay, maxFireDelay);
    }

    //Assigns a random value within the range to publicly accessable varrible
    private void RandomNavDelay()
    {
        navDelay = Random.Range(minNavDelay, maxNavDelay);
    }

    //Returns a Vector3 position of the NavPoints placed on the map.
    private Vector3 NavPoint()
    {
        int navCount = navPoints.Length;
        //Generates a random number between the number 0 and navCount-1 because int Random.Range is exclusive max
        int num = Random.Range(0, navCount);
        //Debug.LogError(num);
        return navPoints[num].transform.position;
    }
}
