﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour
{
    //konsep: spawn virus dalam interval tertentu

    private float nextSpawn = 0;
    public Transform prefabToSpawn;
    public float spawnRate = 1;
    public float randomDelay = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
    }
}

//uji coba push