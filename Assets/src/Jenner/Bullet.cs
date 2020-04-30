using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public int hitCombo = 0;
  public int levelUp = 10;
  public int damage = 20;
  public float speed = 20f;
  private Rigidbody rigidBody;
  private Vector3 cameraBounds;

    // Start is called before the first frame update
    void Start() {
      rigidBody = this.GetComponent<Rigidbody>();
      rigidBody.velocity = transform.forward * speed;
    }

    void Update() {
      Destroy(gameObject, 1);

      if(hitCombo >= levelUp) {
        damage += 5;
        levelUp *= 2;
        hitCombo = 0;
      }
    }

    void OnTriggerEnter(Collider hitInfo) {

      AutoCannonController enemy = hitInfo.GetComponent<AutoCannonController>();

      //Debug.Log(hitInfo.name);

      if(enemy != null) {
        //enemy.takeDamage(damage);
        hitCombo++;
      }

    }

}
