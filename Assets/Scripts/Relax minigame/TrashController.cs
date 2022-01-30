using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("PaperBall")) {

            GameFlow.instance.currentEfficiency += 0.2f;

        }

    }


}
