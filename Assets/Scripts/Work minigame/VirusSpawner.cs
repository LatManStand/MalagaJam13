using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour{

    public GameObject virusPrefab;
    public float spawnRate;

    void Start() {

        InvokeRepeating("SpawnVirus",2f, spawnRate);

    }


    private void SpawnVirus() {

        Instantiate(virusPrefab, transform.position, Quaternion.identity);

    }

}
