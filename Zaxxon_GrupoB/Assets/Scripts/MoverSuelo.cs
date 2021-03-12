﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSuelo : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer rend;
    [SerializeField] Vector2 despl;
    InitGame InitGame;
    [SerializeField] float scrollSpeed;
    void Start()
    {
        rend = GetComponent<Renderer>();
        GameObject InitEmpty = GameObject.Find("InitObject");
        InitGame = InitEmpty.GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {
        CambioSuelo();
    }

    void CambioSuelo() { 
        if(SpaceshipCollider.muerto == false) {
            scrollSpeed = InitGame.speed / 7;
            float offset = Time.time * scrollSpeed;
            despl = new Vector2(0, -offset);
            //rend.material.SetTextureOffset("Normalmap", despl);
            rend.material.SetTextureOffset("_BumpMap", despl);
        }
    }
}
