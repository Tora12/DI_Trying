using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject tipText = null;
    public float force = 10.0f;
    public GameObject gen1 = null;
    public GameObject gen2 = null;
    public GameObject gen3 = null;
    private GameObject player = null;
    private int phase = 1;
    

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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            tipText.SetActive(true);

            if(Input.GetButtonDown("Hack"))
            {
                if (phase == 1)
                    Phase1();
                else if (phase == 2)
                    Phase2();
                else if (phase == 3)
                    Phase3();
            }
        }
    }

    private void Phase1()
    {
        Destroy(gen1);
        ReplusingBlast();
        phase = 2;
    }

    private void Phase2()
    {
        Destroy(gen2);
        ReplusingBlast();
        phase = 3;
    }

    private void Phase3()
    {
        Destroy(gen3);
        ReplusingBlast();
        Destroy(this, 5);
    }
}
