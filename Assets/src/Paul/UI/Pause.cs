using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    private GameObject clone;
    private bool isPaused = false;

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            isPaused = true;
            player.SetActive(false);
            clone = Instantiate(pauseMenu);
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        isPaused = false;
        Destroy(clone);
        player.SetActive(true);
    }
}
