using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavoirScript : MonoBehaviour
{
    private GameObject mainCharacter;
    [Range(-.5f, .5f)][SerializeField] float Angle=.15f;
    [Range(1f, 40f)][SerializeField] float Distance=20f;
    //[SerializeField] float xOffset=18.29f;
    //[SerializeField] float yOffset=3.59f;
    [SerializeField] float zOffset=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        mainCharacter=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		if(mainCharacter.GetComponent<PlayerHealthandDamage>().dead) return;
        transform.position=new Vector3(Mathf.Cos(Angle)*Distance,mainCharacter.transform.position.y+Mathf.Sin(Angle)*Distance,mainCharacter.transform.position.z+zOffset);
    }
}
