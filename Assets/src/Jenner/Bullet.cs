using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  public Rigidbody projectile;
  public int damage = 40;
  public float speed = 10f;

    // Start is called before the first frame update
    void Start() {

      projectile.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider hitInfo) {

      AutoCannonController enemy = hitInfo.GetComponent<AutoCannonController>();

      if(enemy != null) {
        // enemy.takeDamage(damage);
      }
      Destroy(gameObject);
    }

}
