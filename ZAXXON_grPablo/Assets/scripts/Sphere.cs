using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Sphere : MonoBehaviour
{
    
    [SerializeField] GameObject humo;
    public float speed = 12f;
    [SerializeField] GameObject[] vidasSprite;
    int vidas = 3;
    [SerializeField] TextMeshProUGUI timeText;
    float tiempo=0;
    public AudioClip damage;
    AudioSource audioSourcedmg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Aumentovelocidad");
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        Texto();
        if (speed == 22) { StopCoroutine("Aumentovelocidad"); }
    }

    void MoverNave()
    {
        float PosX = transform.position.x;
        float PosY = transform.position.y;
        float desplY = Input.GetAxis("Vertical");
        float desplX = Input.GetAxis("Horizontal");

        //Restringir movimiento horizontal
        if (PosX > 0 && PosX < 30)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }
        else if(PosX < 0 && desplX > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }
        else if (PosX > 30 && desplX < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX, Space.World);
        }

        //Restringir movimiento vertical
        if (PosY > 0 && PosY < 9)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }
        else if (PosY < 0 && desplY > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }
        else if (PosY > 9 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY, Space.World);
        }

        transform.rotation = Quaternion.Euler(desplY * -10, 0 , desplX * -20);


    }


    void OnTriggerEnter (Collider other){

        if(other.gameObject.tag=="enemigo"){
            if(vidas>=1)
            {
                vidas--;
                audioSourcedmg = GetComponent<AudioSource>();
                audioSourcedmg.PlayOneShot(damage, 0.7F);
                Destroy(vidasSprite[vidas]);
                if(vidas==1)
                {
                    humo.SetActive(true);
                }
            }  
            else
            {
            Time.timeScale=0f;
            SceneManager.LoadScene("GAMEOVER");
            }

        }


   }
   

    IEnumerator Aumentovelocidad()
    {
        for (int n = 0; ; n++){
            speed = speed + 0.5f;
            yield return new WaitForSeconds(3f);
        }
    }


    void Texto()
    {
        tiempo += Time.deltaTime;
        float segundos = (int) tiempo % 60;
        float minutos = (int) ((tiempo / 60) % 60);
        timeText.SetText("TIEMPO VIVO: " + minutos.ToString("00") +":" + segundos.ToString("00"));

    }

}
