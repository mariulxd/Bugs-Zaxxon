using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    [SerializeField] float smoothVelocity = 10.3f;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(playerPosition.position.x - 2.8154f, playerPosition.position.y +1f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }

}
    
