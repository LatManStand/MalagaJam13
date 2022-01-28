using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            Destroy(gameObject);

        }


    }


}
