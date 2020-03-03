using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  public Rigidbody projectile;
  public float speed = 5f;

    // Start is called before the first frame update
    void Start() {
      projectile.velocity = Vector3.forward * speed;
    }

}
