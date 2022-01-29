using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour{

    public float rotationSpeed = 5f;

    void Update() {

        //transform.rotation = Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, rotationSpeed));

    }

}
