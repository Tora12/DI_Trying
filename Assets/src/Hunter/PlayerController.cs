using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
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
        if (collision.gameObject.CompareTag("Enemy"))
            currentHealth -= 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            currentHealth -= 10.0f;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("EnemyBullet"))
        {
            currentHealth -= collider.gameObject.GetComponent<EnemyBullet>().damage;
            GameManager.Instance.despawnEntity(collider.gameObject, 0);
        }
    }
}
