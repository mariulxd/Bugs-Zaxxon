using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour
{
    public GameObject miNave;
    Sphere sphere;

    private Vector3 MyPos;
    //[SerializeField] Vector3 DestPos;
    //private Vector3 FinalPos;

    [SerializeField] float mySpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        miNave = GameObject.Find("Sphere");
        sphere = miNave.GetComponent<Sphere>();

        //sphere = GetComponent<Sphere>();
        //mySpeed = sphere.speed;
        mySpeed = 10f;
        //print(mySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //MyPos = transform.position;
        //FinalPos = MyPos + DestPos * Time.deltaTime * mySpeed;
        //transform.position = FinalPos;
        //print(MyPos);

        if (sphere.speed == 0)
        {
            mySpeed = 0f;

        }
        else if (sphere.speed <= 1)
        {
            mySpeed = 10f;

        }
        else if (sphere.speed <= 5)
        {
            mySpeed = 15f;
           
        }
        else if (sphere.speed <= 10)
        {
            mySpeed = 20f;
          
        }
        else if (sphere.speed <= 25)
        {
            mySpeed = 25f;
            
        }
        else if (sphere.speed <= 50)
        {
            mySpeed = 30f;
         
        }
        else if (sphere.speed <= 100)
        {
            mySpeed = 35f;
       
        }
        else
        {
            mySpeed = 40f;
   
        }

        transform.Translate(Vector3.back * Time.deltaTime * mySpeed);

        if(transform.position.z < -60)
        {
            Destroy(gameObject);
        }
    }
}
