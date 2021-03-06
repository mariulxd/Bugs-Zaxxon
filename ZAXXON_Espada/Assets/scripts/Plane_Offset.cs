using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Offset : MonoBehaviour
{

    Renderer rend;
    [SerializeField] Vector2 despl;
    [SerializeField] float scrollSpeed;

    Sphere sphere;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        GameObject Sphere = GameObject.Find("Sphere");
        sphere = Sphere.GetComponent<Sphere>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (sphere.speed == 0)
        {
            scrollSpeed = 0f;

        }
        else if (sphere.speed <= 8)
        {
            scrollSpeed = 1f;

        }
        else if (sphere.speed <= 9.5)
        {
            scrollSpeed = 1.5f;

        }
        else if (sphere.speed <= 11.5)
        {
            scrollSpeed = 2f;
        }
        else if (sphere.speed <= 13)
        {
            scrollSpeed = 2.5f;

        }
        else if (sphere.speed <= 14.5)
        {
            scrollSpeed = 3f;

        }
        else if (sphere.speed <= 16)
        {
            scrollSpeed = 3.5f;

        }
        else
        {
            scrollSpeed = 4f;

        }

        float offset = Time.time * scrollSpeed;
        despl = new Vector2(0, -offset);

        rend.material.SetTextureOffset("_MainTex", despl);
        rend.material.SetTextureOffset("_BumpMap", despl);

    }
}
