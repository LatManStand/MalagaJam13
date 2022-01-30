using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{

    public Transform[] positions;
    public Transform parent;
    public GameObject confettiPrefab;
    public Transform spawnConfettiPoint;
    
    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("PaperBall")) {

            GameFlow.instance.currentEfficiency += 0.2f;

            transform.position = positions[Random.Range(0, positions.Length)].position;

            GameObject confetti =Instantiate(confettiPrefab, spawnConfettiPoint.position, Quaternion.identity);
            confetti.transform.SetParent(parent);

            Destroy(collision.gameObject);

        }

    }


}
