using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthandDamage : MonoBehaviour
{
    public float health=100.0f;
    public bool dead=false;
    [SerializeField] private GameObject doll;
    [SerializeField] private GameObject body;
	
	float old_health;
    // Start is called before the first frame update
    void Start()
    {
        old_health=health;
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.y<-20) health=0;
        if(health<=0 && !dead){
            Instantiate(doll, transform.position, transform.rotation);
			gameObject.SetActive(false);
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
	public void killPlayer(){
		health=0.0f;
	}
	public void respawnPlayer(){
		dead=false;
		health=old_health;
		gameObject.SetActive(true);
	}
}
