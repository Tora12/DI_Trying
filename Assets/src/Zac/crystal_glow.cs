using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal_glow : MonoBehaviour
{
    float duration = 3.0f;
    float originalRange;

    Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        originalRange = lt.range;
    }

    // Update is called once per frame
    void Update()
    {
        var amplitude = Mathf.PingPong(Time.time, duration);
        amplitude = amplitude / duration * 0.5f + 0.5f;

        lt.range = originalRange * amplitude;
    }
}
