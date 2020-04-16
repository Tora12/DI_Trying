using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float force = 10.0f;
    private GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplusingBlast()
    {
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        if (player != null)
        {
            rigidbody.velocity = -transform.forward * force;
        }
        else
        {
            Debug.LogError("Player Not Found.");
        }
    }
}
