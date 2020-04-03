using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthandDamage : MonoBehaviour
{
    public float health=100.0f;
    public bool dead=false;
    [SerializeField] private GameObject doll;
    [SerializeField] private GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.y<-20) health=0;
        if(health<=0 && !dead){
            Instantiate(doll, transform.position, transform.rotation);
            Destroy(body);
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
