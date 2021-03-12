using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearColumnas : MonoBehaviour
{
    //Variable de tipo Object que contendrá el Prefab a instanciar
    [SerializeField] GameObject MyColumn;
    //Variable de tipo Transform que contendrá el objeto de referencia
    [SerializeField] Transform RefPos;


    //Distancia entre columnas
    [SerializeField] float distObstacle;
    //Vector que usaremos para posicionar las columnas de inicio
    Vector3 newPos;
        
    // Start is called before the first frame update
    void Start()
    {


        //Creo un método que generará las columnas iniciales
        distObstacle = 5f;
        CrearColumnasIniciales();

        //Iniciamos la corrutina que creará las instancias
        StartCoroutine("ColumnCorrutine");


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Método que crea las columnas de inicio
    void CrearColumnasIniciales()
    {
        //Bucle que genera 10 columnas iniciales
        for (int n = 0; n <= 30; n++)
        {
            //Calculo un vector para desplazar en Z la distancia y en X un nº random
            float randomX = Random.Range(0f, 30f);
             float randomY = Random.Range(0f, 8.5f);
            newPos = new Vector3(randomX, randomY, -n * distObstacle);
            Vector3 finalPos = RefPos.position + newPos;
            //Instancio la columna
            Instantiate(MyColumn, finalPos, Quaternion.Euler(0,180,0));
        }
    }

    void CrearColumna()
    {
        //Creo un nuevo vector3 con una posición random en X
        float posRandom = Random.Range(0f, 30f);
        float randomY = Random.Range(0f, 8.5f);
        Vector3 DestPos = new Vector3(posRandom, randomY, 0);
        Vector3 NewPos = RefPos.position + DestPos;
        //Instancio el prefab en la posición del objeto de referencia
        //Como tenemos su componente Transform, le indicamos que lo que quiero es su posición
        Instantiate(MyColumn, NewPos, Quaternion.Euler(0,180,0));
    }

    //Corrutina que se ejecuta cada cierto tiempo
    //IMPORTANTE: el intevalo de creación ahora es fijo pero debería depender de la velocidad de la nave
    IEnumerator ColumnCorrutine()
    {

        for (int n=0; ; n++ )
        {
            
            //Llamo al método que crea las columnas de forma aleatoria
            CrearColumna();
            //Indico a la corrutina que se repita cada segundo
            yield return new WaitForSeconds(0.1f);
        }
    }
}
