using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour{

    public float workValue;

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            GameFlow.instance.AddWork(workValue);

            Destroy(gameObject);

        }


    }


}
