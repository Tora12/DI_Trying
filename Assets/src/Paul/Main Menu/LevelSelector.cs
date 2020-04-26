using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string scene = null;
    public void Levelloader()
    {
        SceneManager.LoadScene(scene);
    }
}
