using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{
    // This is a quick-n-dirty way of doing a singleton structure.  It works in unity and in this game enviroment.
    //    NOTE:: a full lock style of code would be required if the process works on mutliple threads. ERGO not thread safe
    //           except in Unity game engine!
    private static BPM _BPMInstance;
    public float _bpm;
    private float _beatInterval, _beatTimer;
    public static bool _beatFull;
    public static int _beatCountFull;

    private void Awake()
    {
        if (_BPMInstance != null && _BPMInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _BPMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();
    }

    void BeatDetection()
    {
        // Full beat count
        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            //_beatFull
        }
    }
}
