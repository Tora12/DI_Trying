using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public string Scene = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int random(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void levelloader()
    {
        Application.LoadLevel(Scene);

    }
}
