using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverBala : MonoBehaviour
{

    private float velocidad = 3f;
    private SpaceshipMove spaceship;
    [SerializeField] GameObject Nave;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0, 0, transform.position.z * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Nave = GameObject.Find("StarSparrow1");
            spaceship = Nave.GetComponent<SpaceshipMove>();
            spaceship.Contador++;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }



    }
}
