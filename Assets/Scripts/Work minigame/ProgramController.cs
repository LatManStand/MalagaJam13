using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramController : MonoBehaviour{


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            collision.GetComponent<PlayerController>().BackToStart();

        }

    }




}
