using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthandDamage : MonoBehaviour
{
    public float health=100.0f;
    public bool dead=false;
    //[SerializeField] private GameObject doll=null;
	/*
    [SerializeField] private GameObject HealthBar=null;
    [SerializeField] private GameObject canvas=null;
    [SerializeField] private Slider slider=null;
    */
	
	public float max_health;
    // Start is called before the first frame update
    
    void Start()
    {
        max_health=health;
		/*
		slider.maxValue = max_health;
        slider.value = health;
		*/
		
    }
    

    // Update is called once per frame
    void Update()
    {
		
		if(transform.position.y<-20) health=0;
        if(health<=0 && !dead){
            //Instantiate(doll, transform.position, transform.rotation);
			//gameObject.SetActive(false);
            dead=true;
        }
        /*
		if (health < max_health)
        {
            canvas.SetActive(true);
            HealthBar.SetActive(true);
        }
		slider.value=health;
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
			health -=other.GetComponent<EnemyBullet>().damage;
            Destroy(other.gameObject);
            
        }
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.gameObject.GetComponent<Hazard>()!=null)
        {
			health -=collision.transform.gameObject.GetComponent<Hazard>().damage;     
        }
    }
	void OnCollisionStay(Collision collision){
		if (collision.transform.gameObject.GetComponent<Hazard>()!=null)
        {
			health -=collision.transform.gameObject.GetComponent<Hazard>().damage/10;     
        }
	}
	public void killPlayer(){
		health=0.0f;
	}
	public void resetPlayer(){
		dead=false;
		health=max_health;
		//gameObject.SetActive(true);
		//canvas.SetActive(false);
        //HealthBar.SetActive(false);
		
		/*GameObject[] ragDolls =  GameObject.FindGameObjectsWithTag ("RagDoll");
		for(int i = 0 ; i < ragDolls.Length ; i ++)
			Destroy(ragDolls[i]);
		*/
	}
}
