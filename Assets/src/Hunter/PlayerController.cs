using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth, currentHealth;
    public bool isDead;

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
            currentHealth -= 2.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            currentHealth -= collision.gameObject.GetComponent<EnemyBullet>().damage;
            gameTriggers.despawnEntity(collision.gameObject, 0);
        }

        if (collision.gameObject.tag == "Enemy")
            currentHealth -= 10.0f;
    }
}
