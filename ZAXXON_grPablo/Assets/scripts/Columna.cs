using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour
{
    
    public GameObject Nave;
    private Sphere sphere;

    private Vector3 MyPos;
    //[SerializeField] Vector3 DestPos;
    //private Vector3 FinalPos;

    //Variable velocidad
    public float mySpeed;


    // Start is called before the first frame update
    void Start()
    {


        Nave = GameObject.Find("Nave");
        sphere = Nave.GetComponent<Sphere>();
        //mySpeed = sphere.speed;
        mySpeed = 25f;
        //print(mySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //MyPos = transform.position;
        //FinalPos = MyPos + DestPos * Time.deltaTime * mySpeed;
        //transform.position = FinalPos;
        //print(MyPos);

        transform.Translate(Vector3.back * Time.deltaTime * -mySpeed);

        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
