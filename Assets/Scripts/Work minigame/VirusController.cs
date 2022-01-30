using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour{

    public float virusValue;
    public float lifeTime;
    public float speedX;
    public float speedY;
    public GameObject sound;

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            GameFlow.instance.AddWork(virusValue);

            Destroy(Instantiate(sound),2f);

            Destroy(gameObject);

        }

    }

    void Start() {

        

    }

    void Update() {

        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

    }

    public void SetVirus(float newSpeedX, float newSpeedY, float newLifeTime) {

        speedX = newSpeedX;
        speedY = newSpeedY;
        lifeTime = newLifeTime;

        Destroy(gameObject, lifeTime);

    }

}
