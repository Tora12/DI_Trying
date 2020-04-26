using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class glow_pulse : MonoBehaviour
{
    public PostProcessVolume ppProfile;
    private bool glow_grow = true;

    private void Start()
    {
        ppProfile = GetComponent<PostProcessVolume>();

    }

    private void FixedUpdate()
    {

        Fluctuate_Glow();
    }

    private void Fluctuate_Glow()
    {
        if (glow_grow == true)
        {
            ppProfile.weight += 0.01f;
            if (ppProfile.weight > .9f)
            {
                glow_grow = false;
            }
        }
        else
        {
            ppProfile.weight -= 0.01f;
            if(ppProfile.weight <= 0.1f)
            {
                glow_grow = true;
            }
        }
    }
}
