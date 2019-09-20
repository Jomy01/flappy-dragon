using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_obstaculos : MonoBehaviour
{
    //al hacerla publica podemos modificar la velocidad en unity
    public float velocidad = 5.0f;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // ponemos += para que continue moviendose y multiplicamos por Time para
        //que no vaya hacia la izquierda ocmo un rayo
        transform.position += Vector3.left * velocidad * Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bolafuego")
        {
            Destroy(gameObject);
        }
    }

}
