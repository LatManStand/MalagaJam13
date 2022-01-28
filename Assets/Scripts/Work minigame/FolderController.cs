using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderController : MonoBehaviour{

    public bool open = false;

    public Sprite openSprite;


    void OnTriggerEnter2D(Collider2D collision) {

        if (open && collision.CompareTag("Player")) {

            transform.parent.GetComponent<Room>().GoalReached();

        }

    }



    public void OpenFolder() {

        GetComponent<SpriteRenderer>().sprite = openSprite;

        open = true;

    }


}
