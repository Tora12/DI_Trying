using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) //gets called when the AutoCannon is collided with
    {
        if (collision.transform.gameObject.name == "ThirdPersonController") //checks if the AutoCannon collided with the player
            Destroy(gameObject); //destroys the AutoCannon
    }
}
