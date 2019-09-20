using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedillas : MonoBehaviour
{
    public float velocidad = 5.0f;
    public GameObject coinPrefab;
    public float verticalRandom;
    public float horizontalRandom;
    public float spawnTime = 5.0f;

    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnTime);
        
    }

   

    void Spawn()
    {
        // Vector3 randomDisplacement;
        //float randomHorizontalVariation = Random.Range(-horizontalRandom, +horizontalRandom);
        //float randomVerticalVariation = Random.Range(-verticalRandom, +verticalRandom);

        //randomDisplacement.x = randomHorizontalVariation;
        //randomDisplacement.y = randomVerticalVariation;
        //randomDisplacement.z = 0f;

        //Vector3 spawnPosition = transform.position + randomDisplacement;

        //Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        
            Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(-4f, 3f), 0), Quaternion.identity);
        }
    }
   
