using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(TowerMovement))]
public class TowerController : MonoBehaviour
{
    [Header("Scripts")]
    //Public
    [Tooltip("This is the script that contains the definitions for movement, and shooting.")]
    public TowerMovement movement = null;

    [Header("Health")]
    //Public
    [Tooltip("The maximum ammount of health that the enemy can have.")]
    public float maxHealth = 10;
    [Tooltip("The health bar slider GameObject.\nThis is for enabling and disabling the health bar.")]
    public GameObject HealthBar;
    [Tooltip("The canvas that the health bar is attached to.")]
    public GameObject canvas;
    [Tooltip("The slider that is the enemy health bar.\nThis is for updating the slider values.")]
    public Slider slider;
    [HideInInspector] public float Health;
    //Private
    private bool Dead = false;
    private readonly int EnemyDespawnTime = 0;
    
    [Header("Shooting")]
    //Public
    [Tooltip("Where you would like the raycast to cast from.")]
    public GameObject eye = null;
    [Tooltip("The shortest time between the enemy firing.")]
    public float minFireDelay = 0.1f;
    [Tooltip("The longest time between the enemy firing.")]
    public float maxFireDelay = 1.0f;
    [Tooltip("The \"agro\" range of the enemy.\nIt controls how far the raycast is shot out.")]
    public int MaxDistance = 20;
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
        Health = maxHealth;

        //Checks if the slider has been assigned to.
        if (slider != null)
        {
            //Set the Heath Bar Maximum value to the Maximum Health
            slider.maxValue = maxHealth;
            //Set the current Health Bar value to the current value of Health
            slider.value = Health;
        }
        else
            Debug.LogError("Health Bar not found.");

        RandomFireDelay();
    }

    void Update()
    {
        //Activates the Health Bar
        if (Health < maxHealth)
        {
            //Checks if the Canvas has been assigned to
            if (canvas != null)
                canvas.SetActive(true);
            else
                Debug.LogError("Canvas not Found.");

            //Checks if the Heealthbar has been assigned to
            if (HealthBar != null)
                HealthBar.SetActive(true);
            else
                Debug.LogError("Health Bar not Found.");
        }

        //Handles Enemy Death Animation Triggering.
        if (Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
            Destroy(gameObject, EnemyDespawnTime);
        }

        //Handles the shooting
        if (eye != null)
        {
            if (Physics.Raycast(eye.transform.position, transform.TransformDirection(Vector3.forward), out _, MaxDistance, layerMask) && !Dead && (Time.time > lastAttackTime + fireDelay))
            {
                movement.Fire();
                lastAttackTime = Time.time;
                RandomFireDelay();
            }
        }
        else
            Debug.LogError("Eye not found.");
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

    //Assigns a random value within the range to publicly accessable varrible
    private void RandomFireDelay()
    {
        fireDelay = Random.Range(minFireDelay, maxFireDelay);
    }
}
