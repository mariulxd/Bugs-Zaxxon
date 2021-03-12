using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_SampleScene : MonoBehaviour
{
    public void volver()
    {
        SceneManager.LoadScene(0);
    }

}
