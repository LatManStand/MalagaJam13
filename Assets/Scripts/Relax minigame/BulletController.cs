using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour{

    public Rigidbody2D rb;

    private Vector2 bulletBelocity;


    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Floor")) {

            GetComponent<AudioSource>().Play();

        }

    }


    private void OnDisable() {

        bulletBelocity = rb.velocity;

    }

    private void OnEnable() {

        rb.velocity = bulletBelocity;

    }

}
