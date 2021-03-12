using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject Spaceship;
    [SerializeField] GameObject Columna;
    [SerializeField] Transform InitPos;
    private float randomNumber;
    Vector3 RandomPos;
    [SerializeField] float distanciaInicial = 8;
    InitGame initgame;
    [SerializeField] GameObject emptyspeed;


    void Start()
    {
        for (int n = 0; n <= 24; n++)
        {
            CrearColumna(n * distanciaInicial);
        }
        StartCoroutine("InstanciadorColumnas");

    }

    //Función que crea una columna en una posición Random
    void CrearColumna(float posZ = 0f)
    {
        randomNumber = Random.Range(-7f, 7f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        for (; ; )
        {
            CrearColumna();
            yield return new WaitForSeconds(1f); 
        }
    }
}
