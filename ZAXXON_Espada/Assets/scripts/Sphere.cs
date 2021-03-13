using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public float speed = 8f;
    float speedSimulated;

    [SerializeField] Text SpeedText;

    [SerializeField] GameObject DistanceObject;
    private Distance distance;

    AudioSource audioSource;
    [SerializeField] AudioClip motor;
    [SerializeField] AudioClip explosion;


    // Start is called before the first frame update
    void Start()
    {
        distance = DistanceObject.GetComponent<Distance>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("SpeedCorrutine");

        audioSource.PlayOneShot(motor, 0.3f);
        StartCoroutine("AumentoVelocidad");

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        if (speed == 17.5) { StopCoroutine("AumentoVelocidad");  }
    }


    void MoverNave()
    {
        float posX = transform.position.x - 2.8154f;
        float posY = transform.position.y;

        float desplY = Input.GetAxis("Vertical");
        float desplX = Input.GetAxis("Horizontal");

        if (posX > -15 && posX < 15 || posX < -15 && desplX > 0 || posX > 15 && desplX < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * desplX);
        }


        if (posY > 1 && posY < 8 || posY < 1 && desplY > 0 || posY > 8 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }

    }
    void CheckSpeed()
    {

        SpeedText.text = "Velocidad: " + speed + "km/h";
    }

    IEnumerator SpeedCorrutine()
    {
        int n;
        for (n = 0; ; n++)
        {
            if (distance.crash == false)
            {
                CheckSpeed();
                yield return new WaitForSeconds(1);
            }
            else
            {
                speed = 0f;
                speedSimulated = 0f;
                SpeedText.text = "Velocidad: " + speedSimulated + "km/h";
                yield return null;
            }
        }
    }
    IEnumerator AumentoVelocidad()
    {
        for (int n = 0; ; n++)
        {
            speed = speed + 0.5f;
            yield return new WaitForSeconds(0.7f);
        }
    }

}
