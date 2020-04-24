using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class glow_pulse : MonoBehaviour
{
    public PostProcessVolume ppProfile;

    private void Start()
    {
        changeProfileWeight();
    }

    void changeProfileWeight()
    {
        ppProfile.weight = 0.0f;
    }

}
