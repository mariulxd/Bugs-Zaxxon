using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

//codigo proporcionado por adrian
    //Posición de la nave para mover la cámara
    [SerializeField] Transform playerPosition;
    [SerializeField] float smoothVelocity = 30f;
    [SerializeField] Vector3 cameraVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Con este código, la cámara seguirá al jugador, pero alejado algo en el eje Z
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 4f, playerPosition.position.z-4);
transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothVelocity);
    }
}
