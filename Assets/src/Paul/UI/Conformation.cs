using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conformation : MonoBehaviour
{
    public void YesExit()
    {
        Application.Quit();
    }

    public void YesMainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
