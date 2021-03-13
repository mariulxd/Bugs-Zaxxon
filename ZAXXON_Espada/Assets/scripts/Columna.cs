using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour
{
    public GameObject miNave;
    Sphere sphere;

    [SerializeField] float mySpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        miNave = GameObject.Find("Sphere");
        sphere = miNave.GetComponent<Sphere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sphere.speed == 0)
        {
            mySpeed = 0f;

        }
        else if (sphere.speed <= 8)
        {
            mySpeed = 10f;

        }
        else if (sphere.speed <= 8.75)
        {
            mySpeed = 15f;
           
        }
        else if (sphere.speed <= 10.75)
        {
            mySpeed = 20f;
          
        }
        else if (sphere.speed <= 12)
        {
            mySpeed = 25f;
            
        }
        else if (sphere.speed <= 13.5)
        {
            mySpeed = 27f;
         
        }
        else if (sphere.speed <= 15)
        {
            mySpeed = 30f;
       
        }
        else
        {
            mySpeed = 35f;
   
        }

        transform.Translate(Vector3.back * Time.deltaTime * mySpeed);
        if(transform.position.z < -60)
        {
            Destroy(gameObject);
        }
    }
}
