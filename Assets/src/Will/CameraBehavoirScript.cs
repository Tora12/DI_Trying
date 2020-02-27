using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavoirScript : MonoBehaviour
{
    private Transform mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
        mainCharacter=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(18.29f,mainCharacter.position.y+3.59f,mainCharacter.position.z);
    }
}
