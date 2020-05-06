using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
	[SerializeField] private GameObject stationaryHook=null;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity=new Vector3(0,-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player")) return;
		gameObject.tag = "Grapple";
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
	}
}
