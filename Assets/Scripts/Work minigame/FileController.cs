using UnityEngine;

public class FileController : MonoBehaviour
{

    public float workValue;
    public GameObject sound;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            GameFlow.instance.AddWork(workValue);

            Room parentRoom = transform.parent.GetComponent<Room>();
            if (parentRoom != null)
            {
                parentRoom.FileTouched();
            }
            Destroy(Instantiate(sound), 2f);

            Destroy(gameObject);
        }
    }


}
