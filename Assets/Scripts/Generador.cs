using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public float tiempoEntreObs = 4.0f;
    public GameObject obstaculoPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, tiempoEntreObs);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Instantiate(obstaculoPrefab, transform.position + new Vector3(0, Random.Range(-4f, 3f), 0), Quaternion.identity);
    }


}
