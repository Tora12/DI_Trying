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
        ui = false;
        bcmode = false;
    }

    public void uiToggle()
    {
        if (ui)
            ui = false;
        else
            ui = true;
    }
}
