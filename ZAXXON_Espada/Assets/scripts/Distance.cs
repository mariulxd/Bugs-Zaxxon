using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Distance : MonoBehaviour
{
    public Text distanciaText;
    public float distancia = 0.0f;
    public bool crash = false;

    [SerializeField] GameObject SphereObject;
    private Sphere sphere;

    public void Start()
    {
        sphere = SphereObject.GetComponent<Sphere>();
        
        StartCoroutine("DistanceCorrutine");
    }
    void CheckDistance() 
    {
        //distancia += Time.deltaTime;
        distancia += 1;
        //print(distancia);
        //print(Time.deltaTime);
        distanciaText.text = "" + distancia.ToString("f0") + "m";
    }

    IEnumerator DistanceCorrutine()
    {
        int n;
        for (n = 0; ; n++)
        {
            while(crash == false)
            {
                CheckDistance();
                yield return new WaitForSeconds(1 * (1 / sphere.speed));
            }
            yield return null;

        }

    }

    /*public void Update()
    {
        distancia += Time.deltaTime;
        distanciaText.text = "" + distancia.ToString("f0") + "m";
    }*/

}
