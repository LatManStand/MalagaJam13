using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonController : MonoBehaviour
{

    public GameObject bulletPrefab;

    public Transform fireTransform;

    public float rotationSpeed;

    private float rotateH;

    public Image chargeBar;

    public Transform parent;

    public float minLaunchForce = 10f;
    public float maxLaunchForce = 25f;
    public float maxChargeTime = 1f;
    public float currentLaunchForce;
    public float chargeSpeed;
    public bool suckerLaunched = false;

    public Transform angMax;
    public Transform angMin;

    public bool clockWise = false;

    private void Start()
    {

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

        currentLaunchForce = minLaunchForce;

    }


    void Update()
    {

        GetInputs();

        //RotateCanon();
        AutoRotateCanon();
        
        FillBar();
        
    }

    private void AutoRotateCanon() {

        if(transform.rotation.z >= angMax.rotation.z && !clockWise) {

            clockWise = true;
            


        }
        else if(transform.rotation.z <= angMin.rotation.z && clockWise) {

            clockWise = false;

        
        }

        if (clockWise) {

            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * -1 * Time.deltaTime);

        }else {
         
            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * 1 * Time.deltaTime);

        }



    }

    private void GetInputs(){

        rotateH = Input.GetAxisRaw("Horizontal");

        if (currentLaunchForce >= maxLaunchForce) {

            currentLaunchForce = maxLaunchForce;
            //Fire();
        }
        if (Input.GetMouseButtonDown(0)){

            currentLaunchForce = minLaunchForce;

        }else if (Input.GetMouseButton(0)) {

            currentLaunchForce += chargeSpeed * Time.deltaTime;


        }else if (Input.GetMouseButtonUp(0)) {

            Fire();

        }


    }

    private void Fire(){

        GameObject bulletInstance = Instantiate(bulletPrefab, new Vector2 (fireTransform.position.x, fireTransform.position.y), fireTransform.rotation);

        bulletInstance.transform.SetParent(parent);

        Debug.Log(fireTransform.forward);
        
        bulletInstance.GetComponent<Rigidbody2D>().velocity = currentLaunchForce * fireTransform.right;


        Destroy(bulletInstance, 20f);



        currentLaunchForce = minLaunchForce;

    }



    private void RotateCanon(){

        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * -rotateH * Time.deltaTime);

    }


    public void BarFill(float amount)
    {
      //  chargeBar.fillAmount = amount;
    }

    private void FillBar(){

     //   BarFill((currentLaunchForce - minLaunchForce)/(maxLaunchForce - minLaunchForce));

    }

}
