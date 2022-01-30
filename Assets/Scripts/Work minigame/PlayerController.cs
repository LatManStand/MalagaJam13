using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Transform startPoint;

    [SerializeField]
    private float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    void Update() {

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.R)) {

            BackToStart();

        }

    }

    void FixedUpdate() {
        movement.Normalize();

        Vector2 totalSpeed = movement * moveSpeed * Mathf.Sqrt(GameFlow.instance.currentEfficiency)* Time.fixedDeltaTime;

        if (GameFlow.instance.work.isActive) {

            rb.MovePosition(rb.position + totalSpeed);
        
        }

    }

    
    public void BackToStart() {

        transform.position = startPoint.position;

    }

}
