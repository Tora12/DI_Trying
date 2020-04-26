using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Rocks : MonoBehaviour
{
    public bool rolling = false;
    public bool bounce = false;
    public float damage = 10.0f;
    public bool activate = false;
    private PlayerHealthandDamage playerHealth;
    private bool playerContact = false;
    private Collision player;
    private new Rigidbody rigidbody;

    private void Start()
    {
        if (rolling || bounce)
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void FixedUpdate()
    {
        if (playerContact)
        {
            playerHealth.health -= damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            player = collision;
            playerContact = true;
            playerHealth = player.transform.gameObject.GetComponent<PlayerHealthandDamage>();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            playerContact = false;
        }
    }
}
