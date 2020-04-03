using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  public int damage = 40;
  public float speed = 10f;
  private Rigidbody rb;
  private Vector3 cameraBounds;

    // Start is called before the first frame update
    void Start() {

      rb = this.GetComponent<Rigidbody>();
      //rb.velocity = new Vector3(0, 0, 1);
      rb.velocity = transform.forward * speed;
      // Trying to calculate camera borders to despawn prefabs
      //cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void OnTriggerEnter(Collider hitInfo) {

      AutoCannonController enemy = hitInfo.GetComponent<AutoCannonController>();

      // check if prefab still in camera's bounds
      if(transform.position.z > cameraBounds.x * -2) {
        Destroy(gameObject);
      }

      if(enemy != null) {
        // enemy.takeDamage(damage);
      }
      Destroy(gameObject);
    }

}
