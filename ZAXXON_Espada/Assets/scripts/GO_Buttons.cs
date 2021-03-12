using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GO_Buttons : MonoBehaviour
{
    public void volver()
    {
        SceneManager.LoadScene(0);
    }

    public void reintentar()
    {
        SceneManager.LoadScene(1);
    }
}
