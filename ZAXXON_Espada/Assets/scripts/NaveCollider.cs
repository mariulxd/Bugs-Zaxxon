using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;

   /* [SerializeField] GameObject  ColumnaObject;
    Columna columna;*/

    [SerializeField] GameObject SphereObject;
    private Sphere sphere;

    [SerializeField] GameObject DistanceObject;
    private Distance distance;

    private void Start()
    {
        distance = DistanceObject.GetComponent<Distance>();
        sphere = SphereObject.GetComponent<Sphere>();
        /*columna = ColumnaObject.GetComponent<Columna>();*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Se ha chocado con un obstáculo");
            distance.crash = true;
            myMesh.enabled = false;

            SceneManager.LoadScene(3);
            /*Invoke("LoadScene", 5.5f);     */


        }
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(3);
    }*/

    /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            print("Se ha chocado con un obstáculo");
            //Destroy(gameObject);

            myMesh.enabled = false;
        }
        
    }*/
}
