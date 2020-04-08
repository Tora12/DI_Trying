using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    public bool bcmode = false;
    public bool ui = false;
    public float volume = 1;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
