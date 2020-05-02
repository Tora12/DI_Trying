using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().UnlockMovementAbillity("GrappleHook");
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}
