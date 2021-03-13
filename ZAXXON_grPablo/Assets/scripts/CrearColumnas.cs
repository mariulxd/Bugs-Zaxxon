using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearColumnas : MonoBehaviour
{
    [SerializeField] GameObject MyColumn;
    [SerializeField] Transform RefPos;
    Vector3 newPos;
    public GameObject Nave;
    private Sphere sphere;

    void Start()
    {
        CrearColumnasIniciales();
        StartCoroutine("ColumnCorrutine");
        StartCoroutine("ColumnCorrutine");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void CrearColumnasIniciales()
    {

        for (int n = 0; n <= 15; n++)
        {
            float randomX = Random.Range(-2f, 32f);
             float randomY = Random.Range(-2f, 11f);
            float randomZ = Random.Range(0f , -170f);
            newPos = new Vector3(randomX, randomY, randomZ);
            Vector3 finalPos = RefPos.position + newPos;
            Instantiate(MyColumn, finalPos, Quaternion.Euler(0,180,0));
        }
    }

    void CrearColumna()
    {
        float posRandom = Random.Range(-2f, 32f);
        float randomY = Random.Range(-2f, 11f);
        Vector3 DestPos = new Vector3(posRandom, randomY, 0);
        Vector3 NewPos = RefPos.position + DestPos;
        Instantiate(MyColumn, NewPos, Quaternion.Euler(0,180,0));
    }

    void Columnaslados()
    {
        int s = Random.Range(0, 4);
        float randomX = Random.Range(-2f, 32f);
        float randomY = Random.Range(-2f, 11f);
        Vector3[] DestPos = new Vector3[] { new Vector3(randomX, -2f, 0f), new Vector3(randomX, 11f, 0f), new Vector3(-2f, randomY, 0f), new Vector3(32f, randomY, 0f) };
        Vector3 NewPos = RefPos.position + DestPos[s];
        Instantiate(MyColumn, NewPos, Quaternion.Euler(0, 180, 0));
    }
    IEnumerator ColumnCorrutine()
    {

        for (int n=0; ; n++ )
        {
            Nave = GameObject.Find("Nave");
            sphere = Nave.GetComponent<Sphere>();
            CrearColumna();
            Columnaslados();
            if (sphere.speed < 15) { yield return new WaitForSeconds(0.8f); }
            else if (sphere.speed >= 15 || sphere.speed < 20) { yield return new WaitForSeconds(0.5f);}
            else { yield return new WaitForSeconds(0.4f); CrearColumna(); }
        }
    }
}
