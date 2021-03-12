using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject SphereObject;
    private Sphere sphere;

    // Start is called before the first frame update
    void Start()
    {
        sphere = SphereObject.GetComponent<Sphere>();
        sphere.SendMessage("SendtoConsole");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * sphere.speed);
    }
}
