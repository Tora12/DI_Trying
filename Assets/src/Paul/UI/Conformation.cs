using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conformation : MonoBehaviour
{
    public void yesExit()
    {
        Application.Quit();
    }

    public void yesMainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
