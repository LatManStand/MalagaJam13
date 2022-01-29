using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour{

    public GameObject virusPrefab;
    public float spawnRate;

    public float newSpeedX;
    public float newSpeedY;
    public float newLifeTime;

    void Start() {

        InvokeRepeating("SpawnVirus",0.5f, spawnRate);

    }


    private void SpawnVirus() {

        Instantiate(virusPrefab, transform.position, Quaternion.identity).GetComponent<VirusController>().SetVirus(newSpeedX, newSpeedY, newLifeTime);

    }

}
