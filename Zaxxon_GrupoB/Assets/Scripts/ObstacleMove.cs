using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    //Creamos la variable a la que se moverá el obtáculo
    //Este valor deberá depender de la velocidad de la nave
    public static float obstacleSpeed;

    public GameObject SpaceShip;
    SpaceshipMove spaceshipMove;

    //Para acceder a las variables globales
    GameObject initObject;
    InitGame initGame;

    // Start is called before the first frame update
    void Start()
    {
        SpaceShip = GameObject.Find("StarSparrow1");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();
        initObject = GameObject.Find("InitObject");
        initGame = initObject.GetComponent<InitGame>();
        obstacleSpeed = initGame.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -12)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.back * Time.deltaTime * obstacleSpeed);
 
    }
}
