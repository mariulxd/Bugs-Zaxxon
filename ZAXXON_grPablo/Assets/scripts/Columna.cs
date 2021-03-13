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
        mySpeed = sphere.speed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * -mySpeed * 1.5f);

        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
