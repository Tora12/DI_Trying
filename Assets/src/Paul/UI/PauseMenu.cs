using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("EventSystem").gameObject.GetComponent<Pause>();
    }


    public void click()
    {
        pause.resume();
    }
}
