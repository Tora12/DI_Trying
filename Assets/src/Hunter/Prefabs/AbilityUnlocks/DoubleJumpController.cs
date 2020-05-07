using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().UnlockMovementAbillity("DoubleJump");
            GameManager.Instance.despawnEntity(gameObject, 0);
        }
    }
}
