using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    private GameObject clone;
    private bool paused = false;

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel") && !paused)
        {
            paused = true;
            player.SetActive(false);
            clone = Instantiate(pauseMenu);
        }
        else if (Input.GetButtonDown("Cancel") && paused)
        {
            resume();
        }
    }

    public void resume()
    {
        paused = false;
        Destroy(clone);
        player.SetActive(true);
    }
}
