using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_sound : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    //public AudioSource bob;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed)
        {

            //bob.volume = 0;
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
    }
}
