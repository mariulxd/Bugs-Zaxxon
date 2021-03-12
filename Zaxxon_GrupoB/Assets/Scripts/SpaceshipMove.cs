using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    public bool inMarginMoveX = true;
    public bool inMarginMoveY = true;
    [SerializeField] Text TextDistance;
    [SerializeField] Text Posicion;
    [SerializeField] Text ObstaculosDestruidos;
    [SerializeField] MeshRenderer myMesh;
    GameObject initObject;
    InitGame initGame;
     public int Contador = 0;
    float Numdistancia;
    float tiempodejuego;
    float lejitos;


    // Start is called before the first frame update
    void Start()
    {
        initObject = GameObject.Find("InitObject");
        initGame = initObject.GetComponent<InitGame>();
        StartCoroutine("Tiempojuego");
        tiempodejuego = 0.00f;
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        TextosUI();
        lejitos = initGame.speed * tiempodejuego;
    }

    void MoverNave()
    {

        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");
        
        float myPosY = transform.position.y;
        float myPosX = transform.position.x;



        if (myPosX < -4.5 && desplX < 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX < -4.5 && desplX > 0)
        {
            inMarginMoveX = true;
        }
        else if (myPosX > 4.5 && desplX > 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX > 4.5 && desplX < 0)
        {
            inMarginMoveX = true;
        }
        //Retricción en Y
        if (myPosY < -0 && desplY < 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY < -0 && desplY > 0)
        {
            inMarginMoveY = true;
        }
        else if (myPosY > 4 && desplY > 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY > 4 && desplY < 0)
        {
            inMarginMoveY = true;
        }

        initGame = initObject.GetComponent<InitGame>();
        if (inMarginMoveX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * initGame.speed * desplX, Space.World);
        }
        if (inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * initGame.speed * desplY, Space.World);
        }

        transform.rotation = Quaternion.Euler(desplY * -20, 0, desplX * -20);
    }

    void TextosUI()
    {
        float myPosY = transform.position.y;
        float myPosX = transform.position.x;
        Posicion.text = "POSICIÓN: X: " + (Mathf.Round(myPosX)) + " Y: " + (Mathf.Round(myPosY));
        TextDistance.text = "DISTANCIA: " + lejitos.ToString("f3"); ;
        ObstaculosDestruidos.text = Contador.ToString();
    }


    IEnumerator Tiempojuego()
    {
        for (int n = 0; ; n++)
        {
            tiempodejuego = tiempodejuego + 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
        