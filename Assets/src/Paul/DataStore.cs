using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : Singleton<DataStore>
{
    public bool bcmode = false;
    public bool ui = false;
    public float volume = 1;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        ui = true;
        bcmode = false;

        float test = float.MaxValue;
    }

    public void UiToggle()
    {
        if (ui)
            ui = false;
        else
            ui = true;
    }
}
