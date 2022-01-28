using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    public RelaxController relax;
    public WorkController work;

    public const float minEfficiency = 0.0f;
    public const float maxEfficiency = 1.0f;
    public float currentEfficiency = maxEfficiency;

    public float workDone = 0.0f;
    public const float workToDo = 100.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (relax == null)
            {
                relax = FindObjectOfType<RelaxController>();
            }

            if (work == null)
            {
                work = FindObjectOfType<WorkController>();
            }
            work.isActive = true;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && work.isActive)
        {
            AddWork(5);
        }
    }

    public void Switch()
    {
        if (work.isActive)
        {
            work.Deactivate();
            relax.Activate();
        }
        else
        {
            work.Activate();
            relax.Deactivate();
        }
    }

    public void AddWork(float ammount)
    {
        if (ammount > 0)
        {
            workDone += ammount * currentEfficiency;
            if (workDone >= workToDo)
            {
                Debug.Log("Win");
            }
        }
        else
        {
            workDone -= ammount;
        }
    }
}
