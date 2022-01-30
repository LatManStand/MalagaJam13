using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramController : MonoBehaviour{

    public bool followPath;


    [SerializeField]
    private float moveSpeed = 2f;

    public Transform[] waypoints;
    public Transform startPoint;
    private int waypointIndex = 0;

    void Start() {

        if (followPath) {

            transform.position = startPoint.position;

        }

    }


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            collision.GetComponent<PlayerController>().BackToStart();
            GetComponent<AudioSource>().Play();
        }

    }




    void Update() {

        if (followPath) {

            Move();
        
        }

    }


    private void Move() {

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if(transform.position == waypoints[waypointIndex].transform.position) {

            waypointIndex += 1;

        }

        if(waypointIndex == waypoints.Length) {

            waypointIndex = 0;

        }

    }

}
