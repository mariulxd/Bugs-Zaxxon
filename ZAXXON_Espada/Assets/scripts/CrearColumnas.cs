using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearColumnas : MonoBehaviour
{
    //Variable de tipo Object que contendrá el Prefab a instanciar
    [SerializeField] GameObject MyColumn;
    //Variable de tipo Transform que contendrá el objeto de referencia
    [SerializeField] Transform RefPos;

    [SerializeField] GameObject SphereObject;
    private Sphere sphere;

    private Vector3 initPos, savedPos;
    private Vector3 nPos = new Vector3(0f, 0f, -10f);

    public float ColumnQuantity;

    // Start is called before the first frame update
    void Start()
    {
        float n;
        initPos = transform.position;
        savedPos = transform.position;
              
        for(n= 0; n<10; n++)
        {
            initPos += nPos;
            transform.position = initPos;
            CrearColumna();
        }

        transform.position = savedPos;

        sphere = SphereObject.GetComponent<Sphere>();

        StartCoroutine("ColumnCorrutine");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            CrearColumna();
        }

    }

    void CrearColumna()
    {
        //Creo un nuevo vector3
        float posRandom = Random.Range(0f, 30f);
        Vector3 DestPos = new Vector3(posRandom, 0, 0);
        Vector3 NewPos = RefPos.position + DestPos;
        //Instancio el prefab en la posición del objeto de referencia
        //Como tenemos su componente Transform, le indicamos que lo que quiero es su posición
        Instantiate(MyColumn, NewPos, Quaternion.identity);
    }

    IEnumerator ColumnCorrutine()
    {
        int n;
        for (n=0; ; n++ )
        {
            //print(n);
            //Intancio el prefab en coordenadas 0,0,0
            //Instantiate(MyColumn);
            CrearColumna();

            /*Dependiendo de la velocidad de la nave se crearán las columnas en mayor o menor cantidad, para mantener la dificultad e ir incrementándola*/

            if (sphere.speed == 0)
            {
                ColumnQuantity = 0f;

            }
            else if (sphere.speed <= 5)
            {
                ColumnQuantity = 1.5f;

            }
            else if (sphere.speed <= 10)
            {
                ColumnQuantity = 2f;

            }
            else if (sphere.speed <= 25)
            {
                ColumnQuantity = 2.5f;

            }
            else if (sphere.speed <= 50)
            {
                ColumnQuantity = 3f;

            }
            else if (sphere.speed <= 100)
            {
                ColumnQuantity = 3.5f;

            }
            else
            {
                ColumnQuantity = 5f;

            }

            yield return new WaitForSeconds(1*(1/ColumnQuantity));
        }
    }
}
