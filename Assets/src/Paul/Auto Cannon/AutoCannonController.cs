using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(AutoCannonMovement))]
public class AutoCannonController : MonoBehaviour
{
    [Header("Scripts")]
    //Public
    public AutoCannonMovement movement = null;

    [Header("Health")]
    //Public
    public float maxHealth = 10;
    public GameObject HealthBar;
    public GameObject canvas;
    public Slider slider;
    public readonly int EnemyDespawnTime = 2;
    [HideInInspector] public float Health;
    //Private
    private bool Dead = false;
    

    [Header("Shooting")]
    //Public
    public GameObject eye = null;
    public float minFireDelay = 0.1f;
    public float maxFireDelay = 1.0f;
    public int MaxDistance = 20;
    //Private
    private float fireDelay;
    private float lastAttackTime;

    [Header("AI")]
    //Public
    public GameObject[] navPoints = null;
    public float minNavDelay = 3.0f;
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
        Health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = Health;
        RandomFireDelay();
        RandomNavDelay();
        if (navPoints != null)
        {
            canNav = true;
            agent = GetComponent<NavMeshAgent>();
        }
    }
    
    void Update()
    {
        if (Health < maxHealth)
        {
            canvas.SetActive(true);
            HealthBar.SetActive(true);
        }

        //Handles Enemy Death Animation Triggering.
        if(Health <= 0 && !Dead)
        {
            //Prevents the Animation from constantly replaying.
            Dead = true;
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

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        if (eye != null)
        {
            if (Physics.Raycast(eye.transform.position, transform.TransformDirection(Vector3.forward), out _, MaxDistance, layerMask) && !Dead && (Time.time > lastAttackTime + fireDelay))
            {
                movement.Fire();
                lastAttackTime = Time.time;
                RandomFireDelay();
            }
        }
        
        if(canNav)
        {
            if((Time.time > lastNavTime + navDelay) && !Dead)
            {
                agent.SetDestination(NavPoint());
                lastNavTime = Time.time;
                RandomNavDelay();
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

    private void fire()
    {
        StartCoroutine(fire_Coroutine());
    }

    IEnumerator fire_Coroutine()
    {
        while (canFire)
        {
            //randomFireDelay();
            //yield return new WaitForSeconds(fireDelay);
            movement.Fire();
            //randomFireDelay();
            //yield return new WaitForSeconds(fireDelay);
            yield return new WaitForSeconds(0);
        }
    }
    */

    private void RandomFireDelay()
    {
        fireDelay = Random.Range(minFireDelay, maxFireDelay);
    }
    
    private void RandomNavDelay()
    {
        navDelay = Random.Range(minNavDelay, maxNavDelay);
    }

    private Vector3 NavPoint()
    {
        int navCount = navPoints.Length;
        int num = Random.Range(0, navCount);
        if (num >= navCount)
        {
            Debug.LogError("FATIAL ERROR, in RANDOM.RANGE");
            Debug.LogError(num);
        }
        
        return navPoints[num].transform.position;
    }
}
