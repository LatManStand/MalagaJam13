using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    public CameraPostPRocess postPRocess;

    public RelaxController relax;
    public WorkController work;

    public GameObject officeRelax;
    public GameObject officeWork;

    public const float minEfficiency = 0.0f;
    public const float maxEfficiency = 1.0f;
    public float currentEfficiency = maxEfficiency;

    public float workDone = 0.0f;
    public const float workToDo = 100.0f;

    public GameObject win;
    public GameObject lose;

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
            postPRocess = FindObjectOfType<CameraPostPRocess>();
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

    }

    public void Switch()
    {
        if (work.isActive)
        {
            MusicManager.instance.ChangeMusic(MusicManager.MusicType.relax);
            work.Deactivate();
            officeWork.SetActive(false);
            postPRocess.enabled = false;
            relax.Activate();
            officeRelax.SetActive(true);
        }
        else
        {
            MusicManager.instance.ChangeMusic(MusicManager.MusicType.work);
            work.Activate();
            officeWork.SetActive(true);
            postPRocess.enabled = true;
            relax.Deactivate();
            officeRelax.SetActive(false);
        }
    }

    public void AddWork(float ammount)
    {
        if (ammount > 0)
        {
            if (work.isActive)
            {
                workDone += ammount * currentEfficiency;
                if (workDone >= workToDo)
                {
                    Win();
                }
            }
        }
        else
        {
            workDone += ammount;
        }
    }

    public void StopBoth()
    {
        MusicManager.instance.StopAll();
        work.Deactivate();
        officeWork.SetActive(false);
        postPRocess.enabled = false;
        relax.Deactivate();
        officeRelax.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void Win()
    {
        StopBoth();
        win.SetActive(true);
    }

    public void Lose()
    {
        StopBoth();
        lose.SetActive(true);
    }
}
