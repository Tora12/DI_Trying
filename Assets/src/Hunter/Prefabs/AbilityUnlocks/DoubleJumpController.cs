using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().UnlockMovementAbillity("DoubleJump");
        }
    }
}
