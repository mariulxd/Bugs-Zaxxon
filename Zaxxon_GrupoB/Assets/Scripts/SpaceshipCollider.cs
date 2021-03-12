using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;
    public GameObject SonidoExplosion;
    public GameObject ExplosionParticulas;
    SpaceshipMove spaceship;
    [SerializeField] GameObject Nave;
    public AudioClip explosion;
    AudioSource audioSourceExp;
    public static bool muerto = false;

    GameObject initObject;
    InitGame initGame;
    Vector3 pos;

    private void Start()
    {
        initObject = GameObject.Find("InitObject");
        initGame = initObject.GetComponent<InitGame>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            muerto = true;
            Nave = GameObject.Find("StarSparrow1");
            spaceship = Nave.GetComponent<SpaceshipMove>();
            spaceship.StopCoroutine("Tiempojuego");
            myMesh.enabled = false;
            pos = transform.position;
            audioSourceExp = GetComponent<AudioSource>();
            audioSourceExp.PlayOneShot(explosion, 0.2F);
            ObstacleMove.obstacleSpeed = 0;
            Instantiate(ExplosionParticulas, pos, Quaternion.identity);
            Invoke("CambiarEscena", 1.5f);
        }
    }
  
    void CambiarEscena()
    {
        SceneManager.LoadScene("GameOver");
    }

}
