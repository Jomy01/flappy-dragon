using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{


    public float velocidadScroll = 5.0f;
    //modificamos el offset del fondo para que se vaya moviendo la textuta
    Material miMaterial;


    // Use this for initialization
    void Start()
    {

        miMaterial = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        miMaterial.mainTextureOffset = miMaterial.mainTextureOffset + Vector2.right * velocidadScroll * Time.deltaTime;



    }
}
