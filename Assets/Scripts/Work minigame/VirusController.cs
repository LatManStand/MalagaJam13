using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour{

    public float virusValue;
    public float lifeTime;
    public float speedX;
    public float speedY;

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            GameFlow.instance.AddWork(virusValue);

            Destroy(gameObject);

        }

    }

    void Start() {

        Destroy(gameObject, lifeTime);

    }

    void Update() {

        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

    }

}
