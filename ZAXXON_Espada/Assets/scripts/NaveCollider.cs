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
    AudioSource audioSource;
    [SerializeField] AudioClip explosion;

    private void Start()
    {
        distance = DistanceObject.GetComponent<Distance>();
        sphere = SphereObject.GetComponent<Sphere>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            distance.crash = true;
            myMesh.enabled = false;
            distance = DistanceObject.GetComponent<Distance>();
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(explosion, 0.5f);
            Invoke("GameOver", 2f);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}
