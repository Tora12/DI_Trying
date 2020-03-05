using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavoirScript : MonoBehaviour
{
    private Transform mainCharacter;
    [SerializeField] float xOffset=18.29f;
    [SerializeField] float yOffset=3.59f;
    [SerializeField] float zOffset=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        mainCharacter=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(xOffset,mainCharacter.position.y+yOffset,mainCharacter.position.z+zOffset);
    }
}
