using UnityEngine;

public class Room : MonoBehaviour
{
    public float workOnComplete = 5.0f;
    public int files = 0;
    public Transform start;

    private void Awake()
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.GetComponent<FileController>())
            {
                files++;
            }
        }
        FindObjectOfType<PlayerController>().startPoint = start;
        FindObjectOfType<PlayerController>().BackToStart();
    }

    public void FileTouched()
    {
        files--;
        if (files == 0)
        {
            Debug.Log("Pasan que cosas");
            // Desbloquear folder
            GetComponentInChildren<FolderController>().OpenFolder();
        }
    }

    public void GoalReached()
    {

        GameFlow.instance.AddWork(workOnComplete);

        GameFlow.instance.work.LoadRoom();
    }

}
