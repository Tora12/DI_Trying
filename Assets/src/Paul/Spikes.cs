using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spikes : MonoBehaviour
{
    public float damage = 10.0f;
    private PlayerHealthandDamage playerHealth;
    private bool playerContact = false;
    private Collision player;

    private void FixedUpdate()
    {
        if (playerContact)
        {            
            playerHealth.health -= damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.CompareTag("Player"))
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
