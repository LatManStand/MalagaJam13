using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour{

    public Rigidbody2D rb;

    private Vector2 bulletBelocity;


    private void OnDisable() {

        bulletBelocity = rb.velocity;

    }

    private void OnEnable() {

        rb.velocity = bulletBelocity;

    }

}
