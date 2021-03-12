using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameOver : MonoBehaviour
{
[SerializeField] GameObject primerBoton;
void Start(){
        Time.timeScale=1f;
        EventSystem.current.SetSelectedGameObject(primerBoton);

}
    public void JugarJuego()    
    {
        SceneManager.LoadScene("JUEGO");
    }
    public void IrMenu()    
    {
        SceneManager.LoadScene("INICIO");
    }


    public void SalirJuego()    
    {
      Application.Quit();  
    }
}
