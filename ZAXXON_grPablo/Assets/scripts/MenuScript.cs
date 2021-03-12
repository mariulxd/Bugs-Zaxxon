using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void JugarJuego()    
    {
        SceneManager.LoadScene("JUEGO");
    }
    

    public void SalirJuego()    
    {
      Application.Quit();  
    }
}
