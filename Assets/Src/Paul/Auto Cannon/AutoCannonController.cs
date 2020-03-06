using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonController : MonoBehaviour
{
    public int Health = 100;
    public AutoCannonMovement movement;
    private bool Dead = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Update()
    {
        if(Health == 0 && !Dead)
        {
            Dead = true;
            float num = Random.value;

            if (num <= .25)
                movement.Dead1();
            else if (num <= .5)
                movement.Dead2();
            else if (num <= .75)
                movement.Dead3();
            else
                movement.Dead4();

            //INSERT GAME TRIGGER CALL HERE
        }
    }
}
