using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthandDamage : MonoBehaviour
{
    public float health=100.0f;
    public bool dead=false;
    [SerializeField] private GameObject doll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0 && !dead){
            Instantiate(doll, transform);
            dead=true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            health = health - 10f;
        }
    }
}
