using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    public bool isDead;

    private float currentHealth;
    [SerializeField] private GameTriggers gameTriggers;

    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0 && !isDead)
            isDead = true;
    }

    public void Reset()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            currentHealth -= collision.gameObject.GetComponent<EnemyBullet>().damage;
            gameTriggers.despawnEntity(collision.gameObject, 0);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ENEMY");
            currentHealth -= 1.0f;
        }
    }
}
