using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour{

    public float virusValue;

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            GameFlow.instance.AddWork(virusValue);

            Destroy(gameObject);

        }

    }



}
