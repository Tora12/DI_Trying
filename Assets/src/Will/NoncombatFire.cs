using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoncombatFire : MonoBehaviour
{
	[SerializeField] private GameObject grappleHook=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void launchGrapple(){
		GameObject grapple=Instantiate(grappleHook, transform.position+new Vector3(0,1,0), transform.rotation);
		grapple.GetComponent<Rigidbody>().velocity=new Vector3(0,5,5);
	}
}
