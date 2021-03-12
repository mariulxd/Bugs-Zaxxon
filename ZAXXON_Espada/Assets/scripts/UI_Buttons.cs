using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
  
    public void jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void highscore()
    {
        SceneManager.LoadScene(2);
    }

    public void salir()
    {
        Application.Quit();
    }
}

